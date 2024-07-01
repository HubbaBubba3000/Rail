using System;
using System.Collections.Generic; 
using Rail.Domain.Workout.ValueObjects;
namespace Rail.Domain.Workout;

//agregate set of exercises
public sealed class Training 
{
    public string Title {get;set;}

    public Guid UserID {get;set;}

    public List<IExercise> Exercises {get;set;}

    public int GetCount() => Exercises.Count;

    public void AddExercise(IExercise e) 
    {
        Exercises.Add(e);
    }

}