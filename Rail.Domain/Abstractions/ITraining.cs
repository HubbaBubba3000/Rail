using System.Collections.Generic;
namespace Rail.Domain.Abstractions;

public interface ITraining
{
    public Guid id {get;set;}
    public string Title {get;set;}

    public Guid UserID {get;set;}

    public List<IExercise> Exercises {get;set;}
}