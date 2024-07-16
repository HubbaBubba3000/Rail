using System.Threading;
using Rail.Domain.Profile;
using Rail.Domain.Workout;
using Rail.Domain.Serialization;
using Rail.Database;
using Rail.Database.SQLite;
using Rail.Domain.Abstractions;
using Rail.Database.Abstractions;
using DryIoc;

namespace Rail.Console;

public class ProgramHelper 
{
    public IContainer container;
    public ProgramHelper()
    {
        container = new Container();
        RegisterContainer();
    }
    public void RegisterContainer()
    {
        container.Register<ISqlDb, Sqlite>();
        container.Register<IDBContext, DBContext>();
        container.Register<IBinarySerializer, MessagePackBinarySerializer>();
        container.Register<IUserRepository, UserRepository>();
        container.Register<IWorkoutRepository, WorkoutRepository>();

        container.Register<App>();
    }
}

public static class Program 
{
    
    public static void Main(string[] args) 
    {
        ProgramHelper ph = new();
        var app = ph.container.Resolve<App>();
        app.CommandExecute(args);

    }
}