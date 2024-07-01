using Rail.Domain.Workout.ValueObjects;
namespace Rail.Domain.Abstractions;

public interface IExercise
{
    public string Title {get;set;}

    public List<Muscule> Muscules {get;set;}

}