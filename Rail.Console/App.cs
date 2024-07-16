using System.Collections.Generic;
using System;
using Rail.Domain.Abstractions;
using Rail.Domain.Profile;
using Rail.Domain.Workout;
using System.Runtime.CompilerServices;
using System.Reflection;

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

        Commands = new Dictionary<string, Action>();

        Commands.Add("NewTrain", NewTraining);
        Commands.Add("GetUser", GetProfileInfo);
        Commands.Add("NewExercise", NewExercise);

    }

    public void NewExercise() 
    {
        var e = new Exercise() { Title = "Exercise" };
        var t = workoutrep.GetTrainingByUserId(user.id.ToString()).FirstOrDefault();
        workoutrep.CreateExercise(e);
        t.Exercises.Add(e);
        workoutrep.UpdateTraining(t);
    }
    public void NewTraining() 
    {
        var t = new Training() {  Title = "Train", UserID = user.id };
        workoutrep.CreateTraining( t );
        System.Console.WriteLine($"New Training {t.Title} Created");

    }

    public void GetProfileInfo()
    {
        System.Console.WriteLine($"Username: {user.Name}, Level: {user.Level}, Exp: {user.Exp}");
    }

    public void CommandExecute(string[] args)
    {
        Action a;
        Commands.TryGetValue(args[0],out a);
        a.Invoke();
    }

}