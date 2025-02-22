using Microsoft.Data.Sqlite;

namespace MainWebApi.ExternalServices.Persistence;

public class SqliteConnectionSource : IDbConnection<SqliteConnection>
{
    public Microsoft.Data.Sqlite.SqliteConnection OpenConnection()
    {
        return new Microsoft.Data.Sqlite.SqliteConnection("Data Source=main.db");
    }
}