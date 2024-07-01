using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Rail.Avalonia.ViewModel;
using Rail.Avalonia.View;
using Rail.Database.SQLite;
using Rail.Database.Abstractions;
using DryIoc;

namespace Rail.Avalonia;

public partial class App : Application
{
    private IContainer container;
    public override void Initialize()
    {
        RegisterContainer();
        AvaloniaXamlLoader.Load(this);
    }
    private void RegisterContainer()
    {
        container = new Container();
        container.Register<MainVM>();

        container.Register<ISqlDb, SQLite>();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow() {
                DataContext = Container.Resolve<MainVM>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}