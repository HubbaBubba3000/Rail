
using Rail.Domain.Profile.ValueObjects;
using Rail.Domain.Workout;

namespace Rail.Domain.Abstractions;

public interface IUser
{
    public string Name {get;set;}
    public Guid id {get;set;}

    public Email Email {get;set;}
    public Password Password {get;set;}

    public List<ITraining> Trainings {get;set;}

    public int Level {get;set;}
    public int Exp {get;set;}
}