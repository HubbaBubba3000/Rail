using System;
using Rail.Domain.Abstractions;
using Rail.Domain.Profile.ValueObjects;
using System.Collections.Generic;
namespace Rail.Domain.Profile;

public sealed class User : IUser
{
    public User() { }
    public string Name {get;set;} = "username";
    public Guid id {get;set;} = Guid.NewGuid();

    public Email Email {get;set;}
    public Password Password {get;set;}

    public List<ITraining> Trainings {get;set;} = new();

    public int Level {get;set;} = 1;
    public int Exp {get;set;} = 0;
}
