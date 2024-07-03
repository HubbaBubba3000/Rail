
namespace Rail.Database.Entities;

public sealed class User 
{
    public string Name {get;set;}
    public string id {get;set;}

    public string Email {get;set;}
    public string Password {get;set;}

    public int Level {get;set;}
    public int Exp {get;set;}
}