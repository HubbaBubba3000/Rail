using System.Text;

namespace Rail.Domain.Profile.ValueObjects;

public sealed class Password 
{
    private const string notContain = @",./;'[]{}!@#$%^&*()-=+_<>?|\";
    private byte[] content {get; set;}

    private Password(string word)
    {
        content = Encoding.ASCII.GetBytes(word);
    }
    ///<summary>
    ///Entrypt password to sha256 to save in db (not implemented)
    ///</summary>
    public static Password Encrypt(string word) 
    {
        //not encripted!!!
        
        return new Password(word);
    }
    public static Password GetFromDB(string word) 
    {
        //not encripted!!!
        
        return new Password(word);
    }

    public override string ToString()
    {
        return Encoding.ASCII.GetString(content);
    }
}