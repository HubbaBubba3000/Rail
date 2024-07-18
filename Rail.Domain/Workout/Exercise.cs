using Rail.Domain.Workout.ValueObjects;
using Rail.Domain.Abstractions;
using System.Text;

namespace Rail.Domain.Workout;
public sealed class Exercise : IExercise
{
    public Guid id {get;set;}
    public string Title {get; set;}
    public string Description {get;set;}
    public List<Muscule> Muscules {get; set;} = new();
    public Stuff Stuff {get;set;}

    public Exercise(string title, Muscule muscule, string stuff = "none") 
    {
        Title = title;
        id = Guid.NewGuid();
        Muscules.Add(muscule);
        Stuff = new(stuff);
    }
    public Exercise()   {  }
    public override string ToString() 
    {
        return $" ({id}) {Title} for {Muscules[0].Name} with {Stuff} stuff";
    }

    public string MusculesListToString()
    {
        StringBuilder sb = new();
        foreach (var m in Muscules)
        {
            sb.Append(m.ToString());
            sb.Append(" ");
        }
        return sb.ToString();
    }
}
