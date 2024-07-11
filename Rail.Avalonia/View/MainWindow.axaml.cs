using Avalonia.Controls;
using Rail.Avalonia.ViewModel;
namespace Rail.Avalonia.View;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowVM vm)
    {
        DataContext = vm;
        InitializeComponent();

    }

}