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
            await connection.QueryAsync<Profile, ProfileProject, ProfileProjectImage, ProfileProjectTechnology, Profile>(sql,
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

    public async Task<Profile> Insert(Profile profile)
    {
        await using var connection = _dbConnection.OpenConnection();

        const string profileSql = """
                                  insert into Profile (UserId, ImgUrl, Summary, FirstName, LastName, Email, PhoneNumber)
                                  values (@UserId, @ImgUrl, @Summary, @FirstName, @LastName, @Email, @PhoneNumber);
                                  select last_insert_rowid();
                                  """;

        profile.Id = await connection.ExecuteScalarAsync<int>(profileSql, profile);

        foreach (var project in profile.Projects)
        {
            project.ProfileId = profile.Id;
            
            const string projectSql = """
                                      insert into Project (ProfileId, Title, Description, ImgUrl, CreatedAt, UpdatedAt)
                                      values (@ProfileId, @Title, @Description, @ImgUrl, @CreatedAt, @UpdatedAt);
                                      select last_insert_rowid();
                                      """;

            project.Id = await connection.ExecuteScalarAsync<int>(projectSql, project);

            foreach (var img in project.Imgs)
            {
                img.ProjectId = project.Id;
               
                const string imgSql = "insert into ProjectImage (ProjectId, ImgUrl) values (@ProjectId, @ImgUrl)";
                
                await connection.ExecuteAsync(imgSql, img);
            }

            foreach (var tech in project.Techs)
            {
                tech.ProjectId = project.Id;
                
                const string techSql = "insert into ProjectTechnology (ProjectId, Tech) values (@ProjectId, @Tech)";
                
                await connection.ExecuteAsync(techSql, tech);
            }
        }

        return profile;
    }
}