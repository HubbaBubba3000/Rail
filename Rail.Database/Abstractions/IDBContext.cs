
namespace Rail.Database.Abstractions;

public interface IDBContext
{
    // todo cast to user
    public IEnumerable<User> GetUserByName(string name);
    public IEnumerable<User> GetUserByEmail(string email);
    public IEnumerable<User> GetUserById(string id);

    public void DeleteUser(User user);
    public void CreateUser(User user);
    public void UpdateUser(User user);

    public IEnumerable<Exercise> GetExerciseByTitle(string title);

    public void DeleteExercise(Exercise exercise);
    public void CreateExercise(Exercise exercise);
    public void UpdateExercise(Exercise exercise);

    public IEnumerable<Training> GetTrainingByTitle(string title);

    public void DeleteTraining(Training training);
    public void CreateTraining(Training training);
    public void UpdateTraining(Training training);

}