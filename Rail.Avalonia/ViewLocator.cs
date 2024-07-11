using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Rail.Avalonia.ViewModel;
using Rail.Avalonia.View;
using DryIoc;
using Avalonia;


namespace Rail.Avalonia;
public class ViewLocator : IDataTemplate
{
    public bool SupportsRecycling => false;
    private readonly Dictionary<Type, Func<Control?>> _locator = new();

    public ViewLocator()
    {
        IContainer c = ((App)Application.Current).GetContainer;
        RegisterViewFactory<MainWindowVM, MainWindow>(c);
        RegisterViewFactory<HomePageVM, HomePage>(c);
        RegisterViewFactory<TrainingPageVM, TrainingPage>(c);
        RegisterViewFactory<ProgressingVM, Progressing>(c);
    }
    public Control Build(object data)
    {
        var name = data.GetType().FullName.Replace("VM", "").Replace("ViewModel", "View");
        Console.WriteLine(name);
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type);
        }
        else
        {
            return new TextBlock { Text = "Not Found: " + name };
        }
    }
     private void RegisterViewFactory<TViewModel, TView>(IContainer container)
        where TViewModel : class
        where TView : Control
        => _locator.Add( typeof(TViewModel), container.Resolve<Func<TView>>());

    public bool Match(object data)
    {
        return data is BaseVM;
    }
}