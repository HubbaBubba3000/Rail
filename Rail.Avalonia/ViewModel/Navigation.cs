
using Avalonia;
namespace Rail.Avalonia.ViewModel;
public sealed class Navigation : BaseVM
{
    private BaseVM cur;
    public BaseVM CurrentPage 
    {
        get => cur;
        set {
            cur = value;
            OnPropertyChanged("CurrentPage");
        }
    }

    public Navigation()
    {
    
        CurrentPage = GetVM<HomePageVM>();
    }
    public  BaseVM GetVM<T>( ) where T : BaseVM 
    {
        var vm = ((App)Application.Current).GetContainer.Resolve(typeof(T),DryIoc.IfUnresolved.Throw);
        return (BaseVM)vm;
    }
}