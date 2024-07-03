
namespace Rail.Domain.Profile.ValueObjects;

public sealed class Email
{
    private string email {get;set;}

    public Email(string e) 
    {
        email = e;

    }

    public override string ToString() => email; 
}