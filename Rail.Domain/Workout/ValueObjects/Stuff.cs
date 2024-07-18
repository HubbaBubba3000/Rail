
namespace Rail.Domain.Workout.ValueObjects;

public sealed class Stuff 
{
    public string Name {get;set;}

    public Stuff(string name) 
    {
        Name = name;
    }
    public override string ToString()
    {
        return Name;
    }
}