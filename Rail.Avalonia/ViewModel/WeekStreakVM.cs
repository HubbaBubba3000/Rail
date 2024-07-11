using System.Text;
namespace Rail.Avalonia.ViewModel;

public sealed class WeekStreakVM : BaseVM
{
    private StringBuilder streak;
    public string Streak 
    {
        get {
            
            return streak.ToString();
        }
        set {
            OnPropertyChanged();
        }
    }



    public WeekStreakVM() 
    {

    }
}