
using Rail.Domain.Abstractions;
using Rail.Domain.Profile;
using Rail.Domain.Workout;
using Rail.Domain.Workout.ValueObjects;

namespace Rail.Console;

public sealed class App {
    public Dictionary<string, Action<string[]>> Commands;
    private IWorkoutRepository workoutrep;

    private IUser user;
    public App(IUserRepository ur, IWorkoutRepository wr)
    {
        workoutrep = wr;
        user = ur.GetUser();
        user.Trainings = wr.GetTrainingByUserId(user.id.ToString());

        Commands = new Dictionary<string, Action<string[]>>
        {
            { "getuser", GetProfileInfo },

            { "newtrain", NewTraining },
            { "gettrain", GetTraining },
            // { "edittrain", GetTraining },
            {"deltrain", DeleteTraining },
            { "getexers", GetExerciseList },
            // { "deleteexer", DeleteExercise },
            // { "editexer", EditExercise },
            { "newexer", NewExercise }
        };

    }

    public void NewExercise(string[] args) 
    {
        var e = new Exercise();
        for (int i=0;i<args.Length;i+=2)
        {
            switch (args[i]) {
                case "-t" :
                    e.Title = args[i+1];
                    break;
                case "-d" :
                    e.Description = args[i+1];
                    break;
                case "-s" :
                    e.Stuff = new Stuff(args[i+1]);
                    break;
                case "-m" :
                    e.Muscules.Add(new(args[i+1]));
                    break;
            }
        }

        var t = workoutrep.GetTrainingByUserId(user.id.ToString()).FirstOrDefault();
        workoutrep.CreateExercise(e);
        t.Exercises.Add(e);
        workoutrep.UpdateTraining(t);
        System.Console.WriteLine($"new Exercise {e.Title} (id : {e.id} ) is Created in {t.Title} (id: {t.id})");
    }
    public void NewTraining(string[] args) 
    {
        var t = new Training() {UserID = user.id};
        for (int i=0;i<args.Length;i+=2)
        {
            switch (args[i]) {
                case "-t" :
                    t.Title = args[i+1];
                    break;
            }
        }
        workoutrep.CreateTraining( t );
        System.Console.WriteLine($"New Training {t.Title} (id: {t.id}) Created");

    }
     public void GetTraining(string[] args) 
    {
        var t = workoutrep.GetTrainingByUserId(user.id.ToString()).FirstOrDefault();
        System.Console.WriteLine($"get Training {t.Title} (id: {t.id}), exercises: {t.Exercises.Count}");

    }
    public void DeleteTraining(string[] args) 
    {
        string title = "";
        for (int i=0;i<args.Length;i+=2)
        {
            switch (args[i]) {
                case "-t" :
                    title = args[i+1];
                    break;
            }
        }
        var train = workoutrep.GetTrainingByUserId(user.id.ToString()).Find(t => t.Title == title);
        workoutrep.DeleteTraining(train);
        System.Console.WriteLine($"training {train.Title} was removed");
    }

    public void GetExerciseList(string[] args) 
    {
        var exercises = workoutrep.GetAllExercises();
        foreach (var e in exercises)
            System.Console.WriteLine($"{e.Title} (id: {e.id}) Stuff: {e.Stuff.ToString()}, Muscules: {e.MusculesListToString()}");

    }

    public void GetProfileInfo(string[] args)
    {
        System.Console.WriteLine($"Username: {user.Name}, Level: {user.Level}, Exp: {user.Exp}, id: {user.id}");
    }

    public void CommandExecute(string[] args)
    {
        Action<string[]> a;
        if (Commands.TryGetValue(args[0].ToLower(),out a))
            a.Invoke(args[1..args.Length]);
        else 
            throw new Exception("Command is invalid");
    }

}