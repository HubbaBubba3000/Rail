using Rail.Domain.Abstractions;
using Rail.Domain.Workout.ValueObjects;
using Rail.Database.Abstractions;
namespace Rail.Domain.Workout;

public sealed class WorkoutRepository : IWorkoutRepository
{
    private readonly IDBContext db;
    private readonly IBinarySerializer serializer;

    public WorkoutRepository(IDBContext _db, IBinarySerializer bs)
    {
        db = _db;
        serializer = bs;
    }

#region Mapping

    private Database.Entities.Exercise MapExerciseToEntity(IExercise e)
    {
        return new Rail.Database.Entities.Exercise() 
        {
            id = e.id.ToString(),
            Title = e.Title,
            Description = e.Description,
            Muscules = serializer.Serialize<List<Muscule>>(e.Muscules),
            Stuff = e.Stuff.ToString()
        };
    }
    private Exercise MapEntityToExercise(Database.Entities.Exercise e)
    {
        return new Exercise() 
        {
            id = new Guid(e.id),
            Title = e.Title,
            Description = e.Description,
            Muscules = serializer.Deserialize<List<Muscule>>(e.Muscules),
            Stuff = new Stuff(e.Stuff)
        };
    }
    private Database.Entities.Training MapTrainingToEntity(ITraining t)
    {
        List<Guid> eids = new(); 
        foreach (Exercise e in t.Exercises)
        {
            eids.Add(e.id);
        }
        return new Rail.Database.Entities.Training() 
        {
            id = t.id.ToString(),
            Title = t.Title,
            Userid = t.UserID.ToString(),
            Exercise_ids = serializer.Serialize<List<Guid>>(eids)
        };
    }
    private Training MapEntityToTraining(Database.Entities.Training t)
    {
        List<IExercise> exercises = new();
        foreach (var e in db.GetExercisesById(serializer.Deserialize<List<Guid>>(t.Exercise_ids)))
        {
            exercises.Add(MapEntityToExercise(e));
        }
        return new Training() 
        {
            id = new Guid(t.id),
            Title = t.Title,
            UserID = new Guid(t.Userid),
            Exercises = exercises
        };
    }

#endregion

    public List<ITraining> GetTrainingByUserId(string userid) 
    {
        var list = new List<ITraining>();
        foreach (var t in db.GetTrainingByUserId(userid))
        {
            list.Add(MapEntityToTraining(t));
        }
        return list;
    }
    public void DeleteExercise(IExercise exercise)
    {

        db.DeleteExercise(MapExerciseToEntity(exercise));
    }
    public void CreateExercise(IExercise exercise)
    {
        db.CreateExercise(MapExerciseToEntity(exercise));
    }
    public void UpdateExercise(IExercise exercise)
    {
        db.UpdateExercise(MapExerciseToEntity(exercise));
    }

    public void DeleteTraining(ITraining training)
    {
        db.DeleteTraining(MapTrainingToEntity(training));
    }
    public void CreateTraining(ITraining training)
    {
        db.CreateTraining(MapTrainingToEntity(training));
    }
    public void UpdateTraining(ITraining training)
    {
        db.UpdateTraining(MapTrainingToEntity(training));
    }
}