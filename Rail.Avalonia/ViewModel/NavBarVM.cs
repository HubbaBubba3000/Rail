using Rail.Avalonia.Model;
namespace Rail.Avalonia.ViewModel;

public sealed class NavBarVM : BaseVM
{
    private Navigation navigation;

    public NavBarVM(Navigation n) {
        navigation = n;
    }
    public void MoveToHome()
    {
        navigation.CurrentPage = navigation.GetVM<HomePageVM>();
    }
    public void MoveToProgressing()
    {
        navigation.CurrentPage = navigation.GetVM<ProgressingVM>();
    }
    public void MoveToSettings()
    {
        //navigation.CurrentPage = navigation.GetVM<ProgressingVM>();
    }

}