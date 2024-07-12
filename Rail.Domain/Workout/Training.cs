
using Rail.Domain.Abstractions;
namespace Rail.Domain.Workout;

//agregate set of exercises
public sealed class Training : ITraining
{
    public string Title {get;set;}

    public Guid id {get;set;} = Guid.NewGuid();

    public Guid UserID {get;set;}

    public List<IExercise> Exercises {get;set;} = new();

    public int GetCount() => Exercises.Count;


}