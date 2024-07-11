using Rail.Database.Abstractions;

namespace Rail.Domain.Abstractions;

public interface IUserRepository
{
	//private IDBContext db {get;} 

    public void CreateUser(IUser user);
    public void DeleteUser(IUser user);
    public bool CheckUser(IUser user);
    public IUser GetUser();
}
