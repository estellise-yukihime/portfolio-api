using Dapper;
using Microsoft.Data.Sqlite;
using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence.Sqlite;

public class QueryProfile : IQueryProfile
{
    private readonly IDbConnection<SqliteConnection> _dbConnection;

    public QueryProfile(IDbConnection<SqliteConnection> dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task Insert(Profile profile)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           insert into Profile (UserId, FirstName, LastName, Email, Photo, Title, State, Summary, CreatedAt, UpdatedAt)
                           values (@UserId, @FirstName, @LastName, @Email, @Photo, @Title, @State, @Summary, @CreatedAt, @UpdatedAt);
                           select last_insert_rowid();
                           """;

        profile.Id = await connection.ExecuteScalarAsync<int>(sql, profile);
    }

    public async Task Update(Profile profile)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           update Profile
                           set FirstName = @FirstName,
                               LastName = @LastName,
                               Email = @Email,
                               Photo = @Photo,
                               Title = @Title,
                               State = @State,
                               Summary = @Summary,
                               UpdatedAt = @UpdatedAt
                           where Id = @Id
                           """;

        await connection.ExecuteAsync(sql, profile);
    }

    public async Task Delete(int id)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           delete from Profile
                           where Id = @Id
                           """;

        await connection.ExecuteAsync(sql, new { Id = id });
    }
}