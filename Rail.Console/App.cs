using System.Collections.Generic;
using System;
using Rail.Domain.Abstractions;
using Rail.Domain.Profile;
using Rail.Domain.Workout;
using System.Runtime.CompilerServices;
using System.Reflection;
using Rail.Domain.Workout.ValueObjects;

namespace Rail.Console;

public sealed class App {
    public Dictionary<string, Action> Commands;
    private IWorkoutRepository workoutrep;

    private IUser user;
    public App(IUserRepository ur, IWorkoutRepository wr)
    {
        workoutrep = wr;
        user = ur.GetUser();
        user.Trainings = wr.GetTrainingByUserId(user.id.ToString());

        Commands = new Dictionary<string, Action>
        {
            { "getuser", GetProfileInfo },

            { "newtrain", NewTraining },
            { "gettrain", GetTraining },
            // { "edittrain", GetTraining },
            // {"deletetrain", DeleteTraining}

            { "getexers", GetExerciseList },
            // { "deleteexer", DeleteExercise },
            // { "editexer", EditExercise },
            { "newexer", NewExercise }
        };

    }

    public void NewExercise() 
    {
        var e = new Exercise("push ups", new Muscule("chest"));
        var t = workoutrep.GetTrainingByUserId(user.id.ToString()).FirstOrDefault();
        workoutrep.CreateExercise(e);
        t.Exercises.Add(e);
        workoutrep.UpdateTraining(t);
        System.Console.WriteLine($"new Exercise {e.Title} (id : {e.id} ) is Created in {t.Title} (id: {t.id})");
    }
    public void NewTraining() 
    {
        var t = new Training() {  Title = "Train", UserID = user.id };
        workoutrep.CreateTraining( t );
        System.Console.WriteLine($"New Training {t.Title} (id: {t.id}) Created");

    }
     public void GetTraining() 
    {
        var t = workoutrep.GetTrainingByUserId(user.id.ToString()).FirstOrDefault();
        System.Console.WriteLine($"get Training {t.Title} (id: {t.id}), exercises: {t.Exercises.Count}");

    }

    public void GetExerciseList() 
    {
        var exercises = workoutrep.GetAllExercises();
        foreach (var e in exercises)
            System.Console.WriteLine($"{e.Title} (id: {e.id}) Stuff: {e.Stuff.ToString()}, Muscules: {e.MusculesListToString()}");

    }

    public void GetProfileInfo()
    {
        System.Console.WriteLine($"Username: {user.Name}, Level: {user.Level}, Exp: {user.Exp}, id: {user.id}");
    }

    public void CommandExecute(string[] args)
    {
        Action a;
        if (Commands.TryGetValue(args[0].ToLower(),out a))
            a.Invoke();
        else 
            throw new Exception("Command is invalid");
    }

}