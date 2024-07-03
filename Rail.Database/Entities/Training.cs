
namespace Rail.Database.Entities;

public sealed class Training
{
    public string id;
    public string Title {get;set;}

    public string Userid {get;set;}

    public byte[] Exercise_ids {get;set;}
}