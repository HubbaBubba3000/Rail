using Rail.Domain.Abstractions;
using Rail.Domain.Workout.ValueObjects;
using Rail.Database.Abstractions;
using MessagePack.Formatters;
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
        List<string> muscules = new();
        foreach(var m in e.Muscules)
            muscules.Add(m.Name);
        return new Rail.Database.Entities.Exercise() 
        {
            id = e.id.ToString(),
            Title = e.Title,
            Description = e.Description,
            Muscules = (e.Muscules.Count != 0) ? serializer.Serialize<List<string>>(muscules) : null,
            Stuff = e.Stuff.ToString()
        };
    }
    private Exercise MapEntityToExercise(Database.Entities.Exercise e)
    {
        List<Muscule> muscules = new();
        List<string> emuscules = serializer.Deserialize<List<string>>(e.Muscules);
        foreach (var m in emuscules)
        {
            muscules.Add(new Muscule(m));
        }

        return new Exercise() 
        {
            id = new Guid(e.id),
            Title = e.Title,
            Description = e.Description,
            Muscules = muscules,
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
        List<Guid> ids;
        try {
            ids = serializer.Deserialize<List<Guid>>(t.Exercise_ids);
        }
        catch {
            ids = new();
        }
        if (ids.Count != 0)
        {
            foreach (var e in db.GetExercisesById(ids))
            {
                exercises.Add(MapEntityToExercise(e));
            }
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
        var trainings = db.GetTrainingByUserId(userid);
        foreach (var t in trainings)
        {
            list.Add(MapEntityToTraining(t));
        }
        return list;
    }
    public IExercise GetExerciseById(string id)
    {
        var exercise = db.GetExercisesById(new Guid(id)).FirstOrDefault();
        return MapEntityToExercise(exercise) ;
    }
    public List<IExercise> GetAllExercises()
    {
        var list = new List<IExercise>();
        var exercises = db.GetAllExercises();
        foreach (var e in exercises)
            list.Add(MapEntityToExercise(e));
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