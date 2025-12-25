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

    public async Task Insert(User user)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           insert into User (Username, FirstName, LastName, Email, PhoneNumber, DateOfBirth, CreatedAt, UpdatedAt)
                           values (@Username, @FirstName, @LastName, @Email, @PhoneNumber, @DateOfBirth, @CreatedAt, @UpdatedAt)
                           select last_insert_rowid();
                           """;

       user.Id = await connection.ExecuteScalarAsync<int>(sql, user);
    }

    public async Task Update(User user)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           update User
                           set Username = @Username, 
                               FirstName = @FirstName, 
                               LastName = @LastName, 
                               Email = @Email, 
                               PhoneNumber = @PhoneNumber, 
                               DateOfBirth = @DateOfBirth, 
                               UpdatedAt = @UpdatedAt
                           where Id = @Id
                           """;
        
        await connection.ExecuteAsync(sql, user);
    }
    
    public async Task Delete(int id)
    {
        await using var connection = _dbConnection.OpenConnection();
        
        const string sql = """
                           delete from User
                           where Id = @Id
                           """;
        
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}