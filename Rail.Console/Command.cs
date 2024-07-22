
namespace Rail.Console;
public sealed class Command
{
    public Action<string[]> Action { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Command(string n, Action<string[]> a, string d = "")
    {
        Action = a;
        Name = n;
        Description = d;
    }
}
