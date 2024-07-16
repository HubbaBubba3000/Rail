
using Avalonia;
namespace Rail.Avalonia.ViewModel;
public sealed class NavigationVM : BaseVM
{
    private BaseVM cur;
    public BaseVM CurrentPage 
    {
        get => cur;
        set {
            cur = value;
            OnPropertyChanged();
        }
    }

    public NavigationVM()
    {
        CurrentPage = GetVM<HomePageVM>();
    }
    public BaseVM GetVM<T>( ) where T : BaseVM 
    {
        var vm = ((App)Application.Current).GetContainer.Resolve(typeof(T),DryIoc.IfUnresolved.Throw);
        return (BaseVM)vm;
    }
    public void SetVM<T>( ) where T : BaseVM 
    {
        var vm = ((App)Application.Current).GetContainer.Resolve(typeof(T),DryIoc.IfUnresolved.Throw);
        CurrentPage = (BaseVM)vm;
    }
}