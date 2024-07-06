using Rail.Database.Abstractions;
using Microsoft.Data.Sqlite;
using Rail.Database.Entities;
using System.Data;
using Dapper;

namespace Rail.Database.SQLite;

public sealed class Sqlite : ISqlDb 
{
    public IDbConnection Connection {get;set;}
    public Sqlite() 
    {   

    }
    public void ConnectDB(string path)
    {
        Connection = new SqliteConnection($"DataSource={path}");
        CreateDB();
    }
    private void CreateDB()
    {
        Connection.Query("CREATE TABLE IF NOT EXISTS users (Name TEXT,id TEXT,Email TEXT, Password TEXT, Level INTEGER, Exp INTEGER )");
        Connection.Query("CREATE TABLE IF NOT EXISTS exercises (id TEXT, Title TEXT, Description TEXT, Muscules BLOB, Stuff TEXT)");
        Connection.Query("CREATE TABLE IF NOT EXISTS training (id TEXT, Title TEXT, Userid TEXT, Exercises_ids BLOB)");
    }
    

}