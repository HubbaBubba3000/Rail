

namespace Rail.Domain.Abstractions;

public interface IUserRepository
{
	public IDBContext db {get;set;}

    public void CreateUser(IUser user);
    public void DeleteUser(IUser user);
    public bool CheckUser(IUser user);
}
