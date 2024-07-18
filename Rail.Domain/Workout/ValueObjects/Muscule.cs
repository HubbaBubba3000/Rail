
namespace Rail.Domain.Workout.ValueObjects;

//value object of muscule type
public sealed class Muscule 
{
    public string Name {get;set;}

    public Muscule(string name) {
        Name = name;
    }
    public override string ToString()
    {
        return Name;
    }
}