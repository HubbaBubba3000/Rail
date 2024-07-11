using Rail.Avalonia.Model;
using Rail.Domain.Abstractions;
namespace Rail.Avalonia.ViewModel;

public sealed class HomePageVM : BaseVM
{
    public WeekStreakVM weekStreakVM;  
    private UserContext context; 

    public HomePageVM(WeekStreakVM wsvm, UserContext uc)
    {
        weekStreakVM = wsvm;
        context = uc;
    }

    public List<ITraining> Trainings 
    {
        get => context.User.Trainings;
        set { OnPropertyChanged(); }
    } 
    
}