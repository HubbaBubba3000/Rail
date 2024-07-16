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
        db.ConnectDB("users.db");
    }
#region  user
    // todo cast to User
    public IEnumerable<User> GetUserByName(string name) 
    { 
        return db.Connection.Query<User>("SELECT * FROM users WHERE Name = @Name", new {Name = name});
    }
    public IEnumerable<User> GetAllUsers() 
    { 
        return db.Connection.Query<User>("SELECT * FROM users");
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
    public void UpdateUser(User user) 
    {
        db.Connection.Query("UPDATE users SET Name=@Name, Email=@Email, Password=@Password, Level=@Level, Exp=@Exp WHERE id = @id", user);
    }
#endregion

#region exercise
    public IEnumerable<Exercise> GetExerciseByTitle(string title)
    {
        return db.Connection.Query<Exercise>("SELECT * FROM exercises WHERE Title = @Title", new {Title = title} );
    }
    public IEnumerable<Exercise> GetExerciseById(string Id)
    {
        return db.Connection.Query<Exercise>("SELECT * FROM exercises WHERE id = @id", new {id = Id} );
    }

    public void DeleteExercise(Exercise exercise)
    {
        db.Connection.Query("DELETE FROM exercises WHERE id = @Id", new {Id = exercise.id});
    }
    public void CreateExercise(Exercise exercise) 
    {
        db.Connection.Query("INSERT INTO exercises (Title, id, Description, Muscules, Stuff) VALUES (@Title, @id, @Description, @Muscules, @Stuff)", exercise);
    }
    public void UpdateExercise(Exercise exercise) 
    {
        db.Connection.Query("UPDATE exercises SET Title=@Title, Description=@Description, Muscules=@Muscules, Stuff=@Stuff WHERE id = @id", exercise);
    }
    public IEnumerable<Exercise> GetExercisesById(List<Guid> ids)
    {
        return db.Connection.Query<Exercise>("SELECT * FROM exercises WHERE id = @id", ids );
    }

#endregion

#region training

    public IEnumerable<Training> GetTrainingByTitle(string title)
    {
        return db.Connection.Query<Training>("SELECT * FROM trainings WHERE Title = @Title", new {Title = title} );
    }

    public void DeleteTraining(Training training)
    {
        db.Connection.Query("DELETE FROM trainings WHERE id = @Id", new {Id = training.id});
    }
    public void CreateTraining(Training training)
    {
        db.Connection.Query("INSERT INTO trainings (Title, id, Userid, Exercises_ids) VALUES (@Title, @id, @Userid, @Exercise_ids)", training);
    }
    public void UpdateTraining(Training training)
    {
        db.Connection.Query("UPDATE trainings SET Title=@Title, Userid=@Userid, Exercises_ids=@Exercise_ids, WHERE id = @id", training);

    }


    public IEnumerable<Training> GetTrainingByUserId(string userid)
    {
        return db.Connection.Query<Training>("SELECT * FROM trainings WHERE Userid = @Userid", new {Userid = userid});
    }
    #endregion
}