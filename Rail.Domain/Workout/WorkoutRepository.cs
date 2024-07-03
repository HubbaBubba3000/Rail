using Rail.Domain.Abstractions;
namespace Rail.Domain.Workout;

public sealed class WorkoutRepository : IWorkoutRepository
{
    private readonly IDBContext db;

    public void CreateTraining(Training training)
    {
        
    }
}