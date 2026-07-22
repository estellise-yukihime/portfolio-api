using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(1010, "insert project technologies for default profile")]
public class Insert_1010_ProjectTechnology : Migration
{
    public override void Up()
    {
        Insert.IntoTable("ProjectTechnology")
            .Rows([
                // 1 - SetldPay CI/CD Pipeline
                new
                {
                    ProjectId = 1,
                    Tech = "GitHub Actions"
                },
                new
                {
                    ProjectId = 1,
                    Tech = "CI/CD"
                },
                new
                {
                    ProjectId = 1,
                    Tech = "Azure"
                },

                // 2 - InComm Integration API
                new
                {
                    ProjectId = 2,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 2,
                    Tech = "Dapper"
                },
                new
                {
                    ProjectId = 2,
                    Tech = "JWT"
                },
                new
                {
                    ProjectId = 2,
                    Tech = "Azure Key Vault"
                },

                // 3 - Banking Integration API
                new
                {
                    ProjectId = 3,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 3,
                    Tech = "Entity Framework"
                },
                new
                {
                    ProjectId = 3,
                    Tech = "SQL Server"
                },
                new
                {
                    ProjectId = 3,
                    Tech = "Redis"
                },
                new
                {
                    ProjectId = 3,
                    Tech = "SignalR"
                },
                new
                {
                    ProjectId = 3,
                    Tech = "Azure Key Vault"
                },

                // 4 - Card Program Management API
                new
                {
                    ProjectId = 4,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 4,
                    Tech = "Entity Framework"
                },
                new
                {
                    ProjectId = 4,
                    Tech = "SQL Server"
                },
                new
                {
                    ProjectId = 4,
                    Tech = "Frontegg"
                },
                new
                {
                    ProjectId = 4,
                    Tech = "Azure Key Vault"
                },

                // 5 - Card Program Management Portal
                new
                {
                    ProjectId = 5,
                    Tech = "Angular"
                },
                new
                {
                    ProjectId = 5,
                    Tech = "Typescript"
                },
                new
                {
                    ProjectId = 5,
                    Tech = "TailwindCSS"
                },
                new
                {
                    ProjectId = 5,
                    Tech = "PrimeNG"
                },

                // 6 - Partner Card Management APIs
                new
                {
                    ProjectId = 6,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 6,
                    Tech = "SQL Server"
                },
                new
                {
                    ProjectId = 6,
                    Tech = "PostgreSQL"
                },
                new
                {
                    ProjectId = 6,
                    Tech = "Azure Key Vault"
                },

                // 7 - Card Management Portal Platform
                new
                {
                    ProjectId = 7,
                    Tech = "Angular"
                },
                new
                {
                    ProjectId = 7,
                    Tech = "Typescript"
                },
                new
                {
                    ProjectId = 7,
                    Tech = "TailwindCSS"
                },
                new
                {
                    ProjectId = 7,
                    Tech = "PrimeNG"
                },

                // 8 - Standalone .NET Services
                new
                {
                    ProjectId = 8,
                    Tech = ".NET"
                },

                // 9 - Heavy Machinery Dealer APIs
                new
                {
                    ProjectId = 9,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 9,
                    Tech = "SQL Server"
                },

                // 10 - Heavy Machinery Management App
                new
                {
                    ProjectId = 10,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 10,
                    Tech = "Blazor"
                },
                new
                {
                    ProjectId = 10,
                    Tech = "SQL Server"
                },

                // 11 - Heavy Machinery Parts E-Commerce
                new
                {
                    ProjectId = 11,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 11,
                    Tech = "Blazor"
                },
                new
                {
                    ProjectId = 11,
                    Tech = "SQL Server"
                },
                new
                {
                    ProjectId = 11,
                    Tech = "Stripe"
                },
                new
                {
                    ProjectId = 11,
                    Tech = "Mailjet"
                },

                // 12 - Educational Battle Game
                new
                {
                    ProjectId = 12,
                    Tech = "Unity3D"
                },
                new
                {
                    ProjectId = 12,
                    Tech = "C#"
                },
                new
                {
                    ProjectId = 12,
                    Tech = ".NET"
                },

                // 13 - Hyper-Casual Games
                new
                {
                    ProjectId = 13,
                    Tech = "Unity3D"
                },
                new
                {
                    ProjectId = 13,
                    Tech = "C#"
                },

                // 14 - Exam Test Application
                new
                {
                    ProjectId = 14,
                    Tech = "Unity3D"
                },
                new
                {
                    ProjectId = 14,
                    Tech = "C#"
                },

                // 15 - Game Content Management System
                new
                {
                    ProjectId = 15,
                    Tech = ".NET"
                },
                new
                {
                    ProjectId = 15,
                    Tech = "Java"
                },
                new
                {
                    ProjectId = 15,
                    Tech = "Python"
                },
                new
                {
                    ProjectId = 15,
                    Tech = "Flask"
                },

                // 16 - Member Networking System
                new
                {
                    ProjectId = 16,
                    Tech = "Laravel"
                },
                new
                {
                    ProjectId = 16,
                    Tech = "PHP"
                },
                new
                {
                    ProjectId = 16,
                    Tech = "MySQL"
                },

                // 17 - E-Commerce Sub-Site
                new
                {
                    ProjectId = 17,
                    Tech = "Laravel"
                },
                new
                {
                    ProjectId = 17,
                    Tech = "PHP"
                },
                new
                {
                    ProjectId = 17,
                    Tech = "MySQL"
                }
            ]);
    }

    public override void Down()
    {
        Delete.FromTable("ProjectTechnology")
            .AllRows();
    }
}
