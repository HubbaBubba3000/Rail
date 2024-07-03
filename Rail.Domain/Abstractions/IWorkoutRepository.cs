namespace Rail.Domain.Abstractions;
public interface IWorkoutRepository
{
    private readonly IDBContext db {get;set;}

    public void CreateTraining(Training training);

}