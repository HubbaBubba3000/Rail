using Rail.Domain.Workout.ValueObjects;
namespace Rail.Domain.Abstractions;

public interface IExercise
{
    public Guid id {get;set;}
    public string Title {get; set;}
    public string Description {get;set;}
    public List<Muscule> Muscules {get; set;}
    public Stuff Stuff {get;set;}
}