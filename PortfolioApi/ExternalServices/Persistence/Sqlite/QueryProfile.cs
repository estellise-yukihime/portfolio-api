using Dapper;
using Microsoft.Data.Sqlite;
using PortfolioApi.Entities;
using PortfolioApi.EntityValueObject;
using PortfolioApi.Utilities;

namespace PortfolioApi.ExternalServices.Persistence.Sqlite;

public class QueryProfile : IQueryProfile
{
    private readonly IDbConnection<SqliteConnection> _dbConnection;

    public QueryProfile(IDbConnection<SqliteConnection> dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Paginated<Profile>> ListCardFromPage(Pagination pagination)
    {
        await using var connection = _dbConnection.OpenConnection();

        var parametersForItems = new DynamicParameters();
        var paginationBuilderForItems = new QueryPaginationBuilder(pagination, parametersForItems)
            .ApplySearch()
            .ApplySize()
            .ApplyOffset()
            .InsertSortDi()
            .InsertSortBy("Id")
            .InsertFilter("FirstName", "LastName", "Email");

        var sqlItems = paginationBuilderForItems.Build("""
                                                       select p.Id, p.ExternalId, p.FirstName, p.LastName, p.Email, 
                                                              p.Title, p.Stack, p.State, p.About, p.CreatedAt, 
                                                              p.UpdatedAt, psk.Id, psk.ProfileId, psk.Category, psk.Name, psk.Proficiency
                                                       from Profile p 
                                                       left join ProfileSkill psk on p.Id = psk.ProfileId 
                                                       where (@Search is null or p.FirstName like ''%' || @Search || '%'' 
                                                                  or p.LastName like ''%' || @Search || '%'' 
                                                                  or p.Email like ''%' || @Search || '%'' 
                                                                  or p.Title like ''%' || @Search || '%'') and 
                                                           ($Filter) 
                                                       order by $Sort $Direction
                                                       limit @Size offset @Offset
                                                       """);

        var parametersForTotal = new DynamicParameters();
        var paginationBuilderForTotal = new QueryPaginationBuilder(pagination, parametersForTotal)
            .ApplySearch()
            .InsertFilter("FirstName", "LastName", "Email");

        var sqlTotal = paginationBuilderForTotal.Build("""
                                                       select count(*)
                                                       from Profile
                                                       where (@Search is null or FirstName like ''%' || @Search || '%'' 
                                                                  or LastName like ''%' || @Search || '%'' 
                                                                  or Email like ''%' || @Search || '%'' 
                                                                  or Title like ''%' || @Search || '%'') and
                                                           ($Filter)
                                                       """);

        var items = await connection.QueryAsync<Profile, ProfileSkill, Profile>(sqlItems,
            (p, sk) =>
            {
                p.Skills.Add(sk);

                return p;
            }, parametersForItems, splitOn: "Id");
        var actual = items.GroupBy(p => p.Id)
            .Select(g =>
            {
                var first = g.First();
                first.Skills = g.Select(x => x.Skills.Single()).ToList();

                return first;
            })
            .ToList();
        var total = await connection.QuerySingleAsync<int>(sqlTotal, parametersForTotal);

        return new Paginated<Profile>(actual, pagination.Page, pagination.Size, total);
    }

    public async Task<Profile?> FindFromExternalId(Guid uuid)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           select Id, UserId, FirstName, LastName, Email, Photo, Title, Stack, State, Summary, CreatedAt, UpdatedAt
                           from Profile
                           where ExternalId = @ExternalId
                           """;

        return await connection.QueryFirstOrDefaultAsync<Profile>(sql, new { ExternalId = uuid.ToString() });
    }

    public async Task<Profile?> FindNaviFromExternalId(Guid uuid)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           select p.Id, p.ExternalId, p.FirstName, p.LastName, p.CV
                           from Profile p
                           inner join (select from ProfileCV where id in (select max(id) from ProfileCV group by ProfileId)) 
                               as cv on p.Id = cv.ProfileId
                           where ExternalId = @ExternalId
                           """;

        return await connection.QueryFirstOrDefaultAsync<Profile>(sql, new { ExternalId = uuid.ToString() });
    }

    public async Task Insert(Profile profile)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           insert into Profile (UserId, FirstName, LastName, Email, Photo, Title, Stack, State, Summary, CreatedAt, UpdatedAt)
                           values (@UserId, @FirstName, @LastName, @Email, @Photo, @Title, @Stack, @State, @Summary, @CreatedAt, @UpdatedAt);
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
                               Stack = @Stack,
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