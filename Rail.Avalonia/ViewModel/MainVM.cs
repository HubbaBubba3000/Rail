
namespace Rail.Avalonia.ViewModel;

public sealed class MainVM : BaseVM 
{
    private HeaderVM Header {get;set;}
    private NavBarVM Navbar {get;set;}

    public MainVM(HeaderVM head, NavBarVM nav)
    {
        Header = head;
        Navbar = nav;
    }
    
}