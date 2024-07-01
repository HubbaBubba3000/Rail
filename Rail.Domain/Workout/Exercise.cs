using Rail.Domain.Workout.ValueObjects;
using Rail.Domain.Abstractions;

namespace Rail.Domain.Workout
{

    public sealed class Exercise : IExercise
    {
        public Guid id {get;set;}
        public string Title {get; set;}
        public string Description {get;set;}
        public List<Muscule> Muscules {get; set;}

        public Exercise(string title, Muscule muscule) 
        {
            Title = title;
            Muscules = new();
            Muscules.Add(muscule);
        }
        public override string ToString() 
        {
            return $"{Title} for {Muscules[0].Name}";
        }
    }

}