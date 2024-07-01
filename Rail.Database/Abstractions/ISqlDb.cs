using Rail.Domain.Abstractions;
namespace Rail.Database.Abstractions;

public interface ISqlDb
{
    public void InitDB();

    public void CreateUser(IUser user);
    public void CreateTraining(ITraining training);
    public void CreateExercise(IExercise exercise);

    public void DeleteUser(IUser user);
    public void DeleteTraining(ITraining training);
    public void DeleteExercise(IExercise exercise);
    


}