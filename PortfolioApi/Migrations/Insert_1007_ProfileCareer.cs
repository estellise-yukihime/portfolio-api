using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(1007, "insert career for default profile")]
public class Insert_1007_ProfileCareer : Migration
{
    public override void Up()
    {
        Insert.IntoTable("ProfileCareer")
            .Rows([
                new
                {
                    Id = 1,
                    ProfileId = 1,
                    Name = "Full Scale",
                    Position = ".NET Developer",
                    Joined = new DateTime(2023, 1, 9),
                    Leaved = (DateTime?)null
                },
                new
                {
                    Id = 2,
                    ProfileId = 1,
                    Name = "FreCre, Inc",
                    Position = "Mobile + Game / Backend / .NET Developer",
                    Joined = new DateTime(2019, 9, 1),
                    Leaved = new DateTime(2022, 12, 29)
                },
                new
                {
                    Id = 3,
                    ProfileId = 1,
                    Name = "Tudlo Innovation Solutions Inc",
                    Position = "Web Developer - Intern",
                    Joined = new DateTime(2018, 9, 1),
                    Leaved = new DateTime(2019, 4, 1)
                }
            ]);
    }

    public override void Down()
    {
        Delete.FromTable("ProfileCareer")
            .Row(new { ProfileId = 1 });
    }
}
