using Dapper;
using Microsoft.Data.Sqlite;
using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence.Sqlite;

public class QueryUser : IQueryUser
{
    private readonly IDbConnection<SqliteConnection> _dbConnection;

    public QueryUser(IDbConnection<SqliteConnection> dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<User?> FindFromEmail(string email)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = "select * from User where Email = @Email";

        var user = await connection.QueryFirstOrDefaultAsync<User>(sql, new { Email = email });

        return user;
    }
}