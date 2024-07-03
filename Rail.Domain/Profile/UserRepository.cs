using Rail.Database;
using Rail.Database.Entities;
using Rail.Domain.Abstractions;
using Rail.Domain.Profile.ValueObjects;

namespace Rail.Domain.Profile;

public sealed class UserRepository : IUserRepository 
{
    public List<IUser> Users {get;set;}

    private IDBContext db {get;set;}
    public UserRepository(IDBContext _db) 
    {
        db = _db;
    }

#region Mapping
    private Rail.Database.Entities.User MapUserToEntity(IUser u)
    {
        return new Rail.Database.Entities.User() 
        {
            Name = u.Name,
            id = u.id.ToString(),
            Email = u.Email.ToString(),
            Password = Password.Encrypt(u.Password.ToString()),
            Level = u.Level,
            Exp = u.Exp
        };
    }
#endregion

#region CRUD
    public void DeleteUser(IUser user)
    {
        db.DeleteUser(MapUserToEntity(user));
    }

    public void CreateUser(IUser user) 
    {
        db.CreateUser(MapUserToEntity(user));
    }

    public bool CheckUser(IUser user) 
    {
        return (db.GetUserByEmail(user.Email) != null);
    }
    public void EditUser(IUser user) 
    {

    }

#endregion
}
