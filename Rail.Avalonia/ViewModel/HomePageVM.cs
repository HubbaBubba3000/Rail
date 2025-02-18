using Rail.Avalonia.Model;
using Rail.Domain.Abstractions;
using Rail.Domain.Workout;
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

    public void AddTraining() 
    {
        Training t = new () {
            Title = "Workout plan"
            
        };
        context.AddTraining(t);
        Trainings = new();
    }
    
}