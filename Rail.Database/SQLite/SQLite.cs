using Rail.Database.Abstractions;
using sqlite-net-pcl;

namespace Rail.Database.SQLite;

public sealed class SQLite : ISqlDb 
{
    private SQLiteConnection db;
    public SQLite(string path) 
    {   
        InitDB(path)
    }
    public void InitDB(string path)
    {
        db = new(path);
        db.CreateTable<IUser>();
        db.CreateTable<ITraining>();
        db.CreateTable<IExercise>();

    }

    public void CreateUser(IUser user);
    {
        
    }
    public void CreateTraining(ITraining training);
    public void CreateExercise(IExercise exercise);

    public void DeleteUser(IUser user);
    public void DeleteTraining(ITraining training);
    public void DeleteExercise(IExercise exercise);
}