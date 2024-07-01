
using Rail.Domain.Profile.ValueObjects;

namespace Rail.Domain.Abstractions;

public interface IUser
{
    public string Name {get;set;}
    public Guid id {get;set;}

    public Email Email {get;set;}
    public Password Password {get;set;}
}