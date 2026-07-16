using FluentMigrator;
using PortfolioApi.Entities;

namespace PortfolioApi.Migrations;

[Migration(1002, "insert default profile")]
public class Insert_1002_Profile : Migration
{
    public override void Up()
    {
        Insert.IntoTable("Profile")
            .Row(new
            {
                ExternalId = "33a88871-2a53-47db-98a3-c479c196f4f5",
                UserId = 1,
                FirstName = "Carlo",
                LastName = "Caballero",
                Email = "apply.estellise.caballero@gmail.com",
                Photo = "",
                Title = "Senior Software Developer",
                Stack = ".NET",
                About = "A software developer of 7+ years building reliable, maintainable, and scalable systems.",
                State = "Cebu",
                Summary =
                    "A software developer specializing in C# and .NET technologies, with expertise in building .NET services and APIs. I\ndesign, develop, and maintain .NET applications and APIs that are efficient, scalable, reliable, and maintainable",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
    }

    public override void Down()
    {
        Delete.FromTable("Profile")
            .Row(new { Email = "apply.estellise.caballero@gmail.com" });
    }
}