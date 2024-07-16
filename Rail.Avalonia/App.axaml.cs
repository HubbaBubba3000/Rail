using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using DryIoc;
using Rail.Avalonia.ViewModel;
using Rail.Avalonia.View;
using Rail.Avalonia.Model;

using Rail.Domain.Abstractions;
using Rail.Domain.Profile;
using Rail.Domain.Workout;
using Rail.Domain.Serialization;

using Rail.Database.SQLite;
using Rail.Database;
using Rail.Database.Abstractions;


namespace Rail.Avalonia;

public partial class App : Application
{
    private IContainer container;

    public IContainer GetContainer => container;
    public override void Initialize()
    {
        RegisterContainer();
        AvaloniaXamlLoader.Load(this);
    }
    private void RegisterContainer()
    {
        container = new Container();
        container.Register<ISqlDb, Sqlite>();
        container.Register<IDBContext, DBContext>();
        container.Register<IBinarySerializer, MessagePackBinarySerializer>();
        container.Register<IUserRepository, UserRepository>();
        container.Register<IWorkoutRepository, WorkoutRepository>();

        container.Register<UserContext>();

        container.Register<NavigationVM>();
        container.Register<MainWindowVM>();
        container.Register<NavBarVM>();
        container.Register<HeaderVM>();
        container.Register<HomePageVM>();
        container.Register<WeekStreakVM>();
        container.Register<ProgressingVM>();

        container.Register<HomePage>();
        container.Register<TrainingPage>();
        container.Register<MainWindow>();
        container.Register<Progressing>();
        container.Register<Navigation>();
    }

    public override void OnFrameworkInitializationCompleted()
    {

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = container.Resolve<MainWindow>() ;
        }

        base.OnFrameworkInitializationCompleted();
    }
}