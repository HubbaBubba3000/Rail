using Rail.Avalonia.Model;
namespace Rail.Avalonia.ViewModel;

public sealed class NavBarVM : BaseVM
{
    private NavigationVM navigation;

    public NavBarVM(NavigationVM n) {
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