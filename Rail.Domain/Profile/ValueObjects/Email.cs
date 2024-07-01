
namespace Rail.Domain.Profile.ValueObjects;

public sealed class Email
{
    private string email {get;set;}

    public override string ToString() => email; 
}