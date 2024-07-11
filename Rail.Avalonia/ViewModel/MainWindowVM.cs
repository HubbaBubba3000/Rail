using Avalonia;
namespace Rail.Avalonia.ViewModel;

public sealed class MainWindowVM : BaseVM 
{
    private BaseVM cur;
    public BaseVM CurrentPage {
        get => cur;
        set {
            cur = value;
            OnPropertyChanged();
        }
    }
    private HeaderVM Header {get;set;}
    private NavBarVM Navbar {get;set;}

    private BaseVM GetVM<T>( ) where T : BaseVM 
    {
        var vm = ((App)Application.Current).GetContainer.Resolve(typeof(T),DryIoc.IfUnresolved.Throw);
        return (BaseVM)vm;
    }

    public MainWindowVM(HeaderVM head, NavBarVM nav )
    {
        Header = head;
        Navbar = nav;
        CurrentPage = GetVM<HomePageVM>();
    }
    
    public void MoveToHome()
    {
        CurrentPage = GetVM<HomePageVM>();
    }
    public void MoveToProgressing()
    {
        CurrentPage = GetVM<ProgressingVM>();
    }
}