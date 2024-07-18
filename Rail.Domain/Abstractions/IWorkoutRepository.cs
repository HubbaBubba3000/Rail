using Rail.Database.Abstractions;
using System.Collections.Generic;
namespace Rail.Domain.Abstractions;

public interface IWorkoutRepository
{
    //private IDBContext db {get;}

    public List<ITraining> GetTrainingByUserId(string userid);
    public IExercise GetExerciseById(string id);
    public List<IExercise> GetAllExercises();
    public void DeleteExercise(IExercise exercise);
    public void CreateExercise(IExercise exercise);
    public void UpdateExercise(IExercise exercise);

    public void DeleteTraining(ITraining training);
    public void CreateTraining(ITraining training);
    public void UpdateTraining(ITraining training);

}