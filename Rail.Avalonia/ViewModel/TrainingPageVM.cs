using Rail.Avalonia.Model;
using Rail.Domain.Abstractions;
namespace Rail.Avalonia.ViewModel;

public sealed class TrainingPageVM : BaseVM
{
    private ITraining training;
    public TrainingPageVM(UserContext uc)
    {
        training = uc.CurrentTraining;
    }

    public string Title 
    {
        get => training.Title;
        set {
            training.Title = value;
        }
    }
    public void AddExercise(IExercise e)
    {
        training.Exercises.Add(e);
    } 
 }