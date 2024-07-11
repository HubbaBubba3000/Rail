using Avalonia.Controls;
using Avalonia;
using Rail.Domain.Workout;
using System.Text;
namespace Rail.Avalonia.View;

public partial class WorkoutControl : UserControl 
{

    public static readonly AvaloniaProperty<Training> TrainingProperty =
        AvaloniaProperty.Register<WorkoutControl, Training>(nameof(Training), defaultValue: null);
    public string Title
    {
        get => ((Training)GetValue(TrainingProperty)).Title;
    }
    public string Description 
    {
        get {
            StringBuilder description = new($" Exercises : {((Training)GetValue(TrainingProperty)).GetCount()}");

            return description.ToString();
        }
    }

    public WorkoutControl() 
    {
        InitializeComponent();
    } 
}