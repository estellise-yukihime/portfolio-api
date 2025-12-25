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

    public async Task<List<Profile>> ListFromUser(string userId)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           select * from Profile prof
                               inner join Project proj
                                   on prof.Id = proj.ProfileId
                               inner join ProjectImage projImg
                                   on proj.Id = projImg.ProjectId
                               inner join ProjectTechnology projTech
                                   on proj.Id = projImg.ProjectTechnologyId
                           where prof.UserId = @UserId
                           """;

        var profiles =
            await connection
                .QueryAsync<Profile, ProfileProject, ProfileProjectImage, ProfileProjectTechnology, Profile>(sql,
                    (profile, project, projectImage, projectTechnology) =>
                    {
                        project.Imgs.Add(projectImage);
                        project.Techs.Add(projectTechnology);

                        profile.Projects.Add(project);

                        return profile;
                    },
                    new { UserId = userId },
                    splitOn: "ProjectId,ProjectImageId,ProjectTechnologyId");

        return profiles.ToList();
    }

    public async Task Insert(Profile profile)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           insert into Profile (UserId, ImgUrl, Summary, FirstName, LastName, Email, PhoneNumber)
                           values (@UserId, @ImgUrl, @Summary, @FirstName, @LastName, @Email, @PhoneNumber);
                           select last_insert_rowid();
                           """;

        profile.Id = await connection.ExecuteScalarAsync<int>(sql, profile);
    }

    public async Task Update(Profile profile)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string sql = """
                           update Profile
                           set Summary = @Summary, 
                               FirstName = @FirstName, 
                               LastName = @LastName, 
                               Email = @Email, 
                               PhoneNumber = @PhoneNumber,
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