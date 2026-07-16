using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(1005, "insert skills for default profile")]
public class Insert_1005_ProfileSkill : Migration
{
    public override void Up()
    {
        Insert.IntoTable("ProfileSkill")
            .Rows([
                new
                {
                    ProfileId = 1,
                    Category = "Backend",
                    Name = "C#",
                    Proficiency = 0.95f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Backend",
                    Name = ".NET",
                    Proficiency = 0.95f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Backend",
                    Name = "ASP.NET Core",
                    Proficiency = 0.9f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Backend",
                    Name = "Entity Framework / EF Core",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Backend",
                    Name = "Dapper",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "Frontend",
                    Name = "Blazor",
                    Proficiency = 0.65f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frontend",
                    Name = "Angular",
                    Proficiency = 0.6f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frontend",
                    Name = "Typescript",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frontend",
                    Name = "JavaScript",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frontend",
                    Name = "CSS",
                    Proficiency = 0.65f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frontend",
                    Name = "HTML",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "DevOps",
                    Name = "Git",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "DevOps",
                    Name = "GitHub",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "DevOps",
                    Name = "GitHub Actions",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "DevOps",
                    Name = "Docker",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "Cloud",
                    Name = "Azure",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Cloud",
                    Name = "Google Cloud Services",
                    Proficiency = 0.6f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "Database",
                    Name = "SQL Server",
                    Proficiency = 0.8f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Database",
                    Name = "PostgreSQL",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Database",
                    Name = "MySQL",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Database",
                    Name = "SQLite",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                }
            ]);
    }

    public override void Down()
    {
        Delete.FromTable("ProfileSkill")
            .Row(new
            {
                ProfileId = 1
            });
    }
}