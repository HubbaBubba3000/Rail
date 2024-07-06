using Rail.Domain.Abstractions;
using Rail.Domain.Workout.ValueObjects;
using Rail.Database.Abstractions;
using Rail.Database;
using Rail.Database.Entities;
using System.Runtime.Serialization;
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

    private Rail.Database.Entities.Exercise MapExerciseToEntity(IExercise e)
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
    private Rail.Database.Entities.Training MapTrainingToEntity(ITraining t)
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

#endregion

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

    }
    public void CreateTraining(ITraining training)
    {

    }
    public void UpdateTraining(ITraining training)
    {

    }
}