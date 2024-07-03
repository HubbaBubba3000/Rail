using System.Data;
namespace Rail.Database.Abstractions;

public interface ISqlDb
{
    IDbConnection Connection {get;set;}

}