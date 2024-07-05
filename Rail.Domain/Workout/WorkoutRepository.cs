using Rail.Domain.Abstractions;
using Rail.Database;
using Rail.Database.Entities;
namespace Rail.Domain.Workout;

public sealed class WorkoutRepository : IWorkoutRepository
{
    private readonly IDBContext db;

#region Mapping

    public byte[] SerializeData(object data) 
    {
        binFormatter = new BinaryFormatter();
        var mStream = new MemoryStream();
        binFormatter.Serialize(mStream, data);

        return mStream.ToArray();
    }

    private Rail.Database.Entities.Exercise MapExerciseToEntity(IExercise e)
    {
        return new Rail.Database.Entities.Exercise() 
        {
            id = e.id.ToString(),
            Title = e.Title,
            Description = e.Description,
            Muscules = SerializeData(e.Muscules),
            Stuff = e.Stuff.ToString()
        };
    }
    private Rail.Database.Entities.Training MapTrainingToEntity(ITraining t)
    {
        //var exercise_ids = 
        return new Rail.Database.Entities.Training() 
        {
            id = t.id,
            Title = t.Title,
            Userid = t.Userid,
            //Exercise_ids = SerializeData(t.Exercises.)
        };
    }

#endregion

    public void DeleteExercise(IExercise exercise)
    {
        db.DeleteExercise(exercise);
    }
    public void CreateExercise(IExercise exercise)
    {
        CreateExercise(exercise);
    }
    public void UpdateExercise(IExercise exercise)
    {
        UpdateExercise(exercise);
    }

    public void DeleteTraining(ITraining training);
    public void CreateTraining(ITraining training);
    public void UpdateTraining(ITraining training);
}