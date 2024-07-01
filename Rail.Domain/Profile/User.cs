using System;
namespace Rail.Domain.Profile;

public sealed class User : IUser
{
    public User(string name, string email, string pass){
        Name = name;
        id = Guid.NewGuid();
        Email = new Email(email);
        Password = new Password(pass);
        Level = 1;
        Exp = 0;
    }
    public string Name {get;set;}
    public Guid id {get;set;}

    public Email Email {get;set;}
    public Password Password {get;set;}

    public int Level {get;set;}
    public int Exp {get;set;}
}