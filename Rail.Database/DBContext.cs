using Dapper;
using System.Collections.Generic;
using Rail.Database.Abstractions;
using Rail.Database.Entities;

namespace Rail.Database;

public sealed class DBContext : IDBContext
{
    ISqlDb db;

    public DBContext(ISqlDb _db)
    {
        db = _db;
    }

    // todo cast to User
    public IEnumerable<User> GetUserByName(string name) 
    { 
        return db.Connection.Query<User>("SELECT * FROM users WHERE Name = @Name", new {Name = name});
    }
    public IEnumerable<User> GetUserByEmail(string email) 
    { 
        return db.Connection.Query<User>("SELECT * FROM users WHERE Email = @Email", new {Email = email});
    }
    public IEnumerable<User> GetUserById(string id) 
    { 
        return db.Connection.Query<User>("SELECT * FROM users WHERE id = @Id", new {Id = id});
    }
    
    public void DeleteUser(User user) 
    {
        db.Connection.Query("DELETE FROM users WHERE id = @Id", new {Id = user.id});
    }
    public void CreateUser(User user) 
    {
        db.Connection.Query("INSERT INTO users (Name, id, Email, Password, Level, Exp) VALUES (@Name,@id,@Email,@Password,@Level,@Exp)", user);
    }
}