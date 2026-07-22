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
                    Category = "Languages",
                    Name = "C#",
                    Proficiency = 0.95f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Languages",
                    Name = "Typescript",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Languages",
                    Name = "JavaScript",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Languages",
                    Name = "SQL",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "Frameworks",
                    Name = ".NET",
                    Proficiency = 0.95f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frameworks",
                    Name = "ASP.NET Core",
                    Proficiency = 0.9f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frameworks",
                    Name = "Blazor",
                    Proficiency = 0.65f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frameworks",
                    Name = "Angular",
                    Proficiency = 0.6f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Frameworks",
                    Name = "Node.js",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "Entity Framework / EF Core",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "Dapper",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "CI/CD",
                    Proficiency = 0.9f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "Git",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "GitHub",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "GitHub Actions",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "Docker",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "Azure",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "Google Cloud Services",
                    Proficiency = 0.6f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "SQL Server",
                    Proficiency = 0.8f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "PostgreSQL",
                    Proficiency = 0.75f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "MySQL",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "Infra & Data",
                    Name = "SQLite",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "IDE",
                    Name = "Rider",
                    Proficiency = 0.9f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "IDE",
                    Name = "WebStorm",
                    Proficiency = 0.9f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "IDE",
                    Name = "DataGrip",
                    Proficiency = 0.9f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "IDE",
                    Name = "VS Code",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "IDE",
                    Name = "Visual Studio",
                    Proficiency = 0.7f,
                    CreatedAt = DateTime.Now
                },

                new
                {
                    ProfileId = 1,
                    Category = "AI",
                    Name = "Claude Code",
                    Proficiency = 0.85f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "AI",
                    Name = "GitHub Copilot",
                    Proficiency = 0.8f,
                    CreatedAt = DateTime.Now
                },
                new
                {
                    ProfileId = 1,
                    Category = "AI",
                    Name = "AI Assistant",
                    Proficiency = 0.75f,
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
