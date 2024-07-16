
namespace Rail.Avalonia.ViewModel;

public sealed class MainWindowVM : BaseVM 
{
    private NavigationVM navigation {get;set;}
    private HeaderVM Header {get;set;}
    private NavBarVM Navbar {get;set;}

    public MainWindowVM(HeaderVM head, NavBarVM nav, NavigationVM n)
    {
        Header = head;
        Navbar = nav;
        navigation = n;
    }
    
}