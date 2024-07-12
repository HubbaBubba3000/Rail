using Rail.Domain.Profile;
using Rail.Domain.Abstractions;

namespace Rail.Avalonia.Model;
///Context for current user
public sealed class UserContext 
{
    private IUserRepository userRepository;
    private IWorkoutRepository workoutRepository;

    public IUser User {get;set;}

    ///Training instance for Training pages
    public ITraining CurrentTraining {get;set;}
    public UserContext(IUserRepository ur, IWorkoutRepository wr)
    {
        userRepository = ur;
        workoutRepository = wr;
        User = userRepository.GetUser();
    }

    public void AddTraining(ITraining t)
    {
        t.UserID = User.id;
        User.Trainings.Add(t);
        workoutRepository.CreateTraining(t);
    }
}