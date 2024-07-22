using Rail.Domain.Abstractions;
using Rail.Domain.Profile;
using Rail.Domain.Profile.ValueObjects;
using Rail.Domain.Workout;
using Rail.Domain.Workout.ValueObjects;

namespace Rail.Console;

public sealed class App
{
    public Dictionary<string, Command> Commands;
    private IWorkoutRepository workoutrep;
    private IUserRepository userrep;

    private IUser user;
    public App(IUserRepository ur, IWorkoutRepository wr)
    {
        workoutrep = wr;
        userrep = ur;
        Commands = new Dictionary<string, Command>
        {
            { "getuser", new Command("getuser", GetProfileInfo, "Get User Info")},
            {"createuser", new Command("createuser", CreateUser, "Create new user ()")},
            {"help", new Command("help",Help, "Get Command List")},
            { "newtrain", new Command("newtrain", NewTraining, "Create New Training ()") },
            { "gettrain", new Command("gettrain", GetTraining, "Get Training by title (-t Title)") },
            { "edittrain", new Command("edittrain", EditTraining, "edit training") },
            {"deltrain", new Command("deltrain",DeleteTraining, "Deleting training by title") },
            { "getexers", new Command("getexers", GetExerciseList, "Get Exercise list") },
             { "delexer", new Command("delexer", DeleteExercise, "Delete Exercise by id ") },
            { "editexer", new Command("editexer", EditExercise, "Edit Exercise") },
            {"starttrain", new Command("starttrain", StartTraining, "Start training")},
            { "newexer", new Command("newexer", NewExercise, "Create new exercise") }
        };

    }
    public void Help(string[] args)
    {
        System.Console.WriteLine("  Rail (Cli) - v0.1");
        System.Console.WriteLine("----------------------");
        foreach (var c in Commands)
        {
            System.Console.WriteLine($"{c.Value.Name} - {c.Value.Description}");
        }
    }
    public void StartTraining(string[] args)
    {
        string title = "";
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-t":
                    title = args[i + 1];
                    break;
            }
        }
        var training = workoutrep.GetTrainingByUserId(user.id.ToString()).Find(t => t.Title == title);

        System.Console.WriteLine($"{training.Title} - {training.Exercises.Count} exercises");
        System.Console.WriteLine("-------------------------");
        foreach (var e in training.Exercises)
        {
            System.Console.WriteLine($"> {e.Title} ");
            System.Console.ReadKey();
        }
        System.Console.WriteLine("Training was Completed, Gain 10 exp");
        user.Exp += 10;
        //update user
    }
    public void EditExercise(string[] args)
    {
        var e = workoutrep.GetExerciseById(args[0]);
        for (int i = 1; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-t":
                    e.Title = args[i + 1];
                    break;
                case "-d":
                    e.Description = args[i + 1];
                    break;
                case "-s":
                    e.Stuff = new Stuff(args[i + 1]);
                    break;
                case "-m":
                    e.Muscules.Add(new(args[i + 1]));
                    break;
            }
        }
        workoutrep.UpdateExercise(e);
        System.Console.WriteLine($"new Exercise {e.Title} (id : {e.id} ) was updated");
    }

    public void EditTraining(string[] args)
    {
        var t = workoutrep.GetTrainingByUserId(user.id.ToString()).FirstOrDefault();
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-t":
                    t.Title = args[i + 1];
                    break;
            }
        }
        workoutrep.UpdateTraining(t);
        System.Console.WriteLine($"Training {t.Title} (id: {t.id}) was updated");
    }
    public void DeleteExercise(string[] args)
    {
        string id = "";
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-id":
                    id = args[i + 1];
                    break;
            }
        }
        var exer = workoutrep.GetExerciseById(id);
        workoutrep.DeleteExercise(exer);
        System.Console.WriteLine($"exercise {exer.Title} (id: {exer.id}) was removed");
    }

    public void CreateUser(string[] args)
    {
        var u = new User();
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-n":
                    u.Name = args[i + 1];
                    break;
                case "-e":
                    u.Email = new(args[i + 1]);
                    break;
                case "-p":
                    u.Password = Password.Encrypt(args[i + 1]);
                    break;
            }
        }
        userrep.CreateUser(u);
    }

    public void NewExercise(string[] args)
    {
        var e = new Exercise();
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-t":
                    e.Title = args[i + 1];
                    break;
                case "-d":
                    e.Description = args[i + 1];
                    break;
                case "-s":
                    e.Stuff = new Stuff(args[i + 1]);
                    break;
                case "-m":
                    e.Muscules.Add(new(args[i + 1]));
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
        var t = new Training() { UserID = user.id };
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-t":
                    t.Title = args[i + 1];
                    break;
            }
        }
        workoutrep.CreateTraining(t);
        System.Console.WriteLine($"New Training {t.Title} (id: {t.id}) Created");

    }
    public void GetTraining(string[] args)
    {
        string title = "";
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-t":
                    title = args[i + 1];
                    break;
            }
        }
        var t = workoutrep.GetTrainingByUserId(user.id.ToString())
                            .Find(tr => tr.Title == title);
        System.Console.WriteLine($"get Training {t.Title} (id: {t.id}), exercises: {t.Exercises.Count}");

    }
    public void DeleteTraining(string[] args)
    {
        string title = "";
        for (int i = 0; i < args.Length; i += 2)
        {
            switch (args[i])
            {
                case "-t":
                    title = args[i + 1];
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
        if (args.Length == 0)
        {
            Help(args);
            return;
        }
        string command = args[0].ToLower();
        if (command != "createuser")
        {
            user = userrep.GetUser();
            if (user == null)
                throw new NullReferenceException("no current user");
        }
        Command c;
        if (Commands.TryGetValue(command, out c))
            c.Action.Invoke(args[1..args.Length]);
        else
            throw new Exception("Command is invalid");
    }

}
