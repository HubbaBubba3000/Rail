using System.Text.Encoding;

namespace Rail.Domain.Profile.ValueObjects;

public sealed class Password 
{
    public byte[] Contain {get; private set;}

    public Password(string word)
    {
        //not encripted!!!
        Contain = Encoding.ASCII.GetBytes(word);
    }
}