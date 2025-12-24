using Microsoft.Data.Sqlite;

namespace PortfolioApi.ExternalServices.Persistence.Sqlite;

public class SqliteConnectionSource : IDbConnection<SqliteConnection>
{
    public SqliteConnection OpenConnection()
    {
        return new SqliteConnection("Data Source=main.db");
    }
}