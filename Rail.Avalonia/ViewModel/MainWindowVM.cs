using Rail.Avalonia.Model;
namespace Rail.Avalonia.ViewModel;

public sealed class MainWindowVM : BaseVM 
{
    public BaseVM CurrentPage {
        get => navigation.CurrentPage;
        set {
            navigation.CurrentPage = value;
            OnPropertyChanged("CurrentPage");
        }
    }
    private Navigation navigation;
    private HeaderVM Header {get;set;}
    private NavBarVM Navbar {get;set;}

    public MainWindowVM(HeaderVM head, NavBarVM nav, Navigation n)
    {
        Header = head;
        Navbar = nav;
        navigation = n;
    }
    
}