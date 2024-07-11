using Rail.Database;
using Rail.Database.Entities;
using Rail.Database.Abstractions;
using Rail.Domain.Abstractions;
using Rail.Domain.Profile.ValueObjects;

using System.Linq;

namespace Rail.Domain.Profile;

public sealed class UserRepository : IUserRepository 
{
    public List<IUser> Users {get;set;}

    private readonly IDBContext db;
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
            Password = u.Password.ToString(),
            Level = u.Level,
            Exp = u.Exp
        };
    }
    private User MapEntityToUser(Rail.Database.Entities.User u)
    {
        return new User() 
        {
            Name = u.Name,
            id = Guid.NewGuid(),
            Email = new Email(u.Email),
            Password = Password.GetFromDB(u.Password),
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
        return (db.GetUserByEmail(user.Email.ToString()) != null);
    }
    public IUser GetUser() 
    {
        var u = db.GetAllUsers().FirstOrDefault();
        return MapEntityToUser(u);
    }
    public void EditUser(IUser user) 
    {

    }

#endregion
}
