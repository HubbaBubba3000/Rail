using Rail.Database.Abstractions;

namespace Rail.Domain.Abstractions;

public interface IWorkoutRepository
{
    //private IDBContext db {get;}

    public void DeleteExercise(IExercise exercise);
    public void CreateExercise(IExercise exercise);
    public void UpdateExercise(IExercise exercise);

    public void DeleteTraining(ITraining training);
    public void CreateTraining(ITraining training);
    public void UpdateTraining(ITraining training);

}