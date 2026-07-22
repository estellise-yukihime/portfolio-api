using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(1012, "insert education for default profile")]
public class Insert_1012_ProfileEducation : Migration
{
    public override void Up()
    {
        Insert.IntoTable("ProfileEducation")
            .Rows([
                new
                {
                    ProfileId = 1,
                    Degree = "Bachelor of Science",
                    DegreeAbbrev = "BS",
                    FieldOfStudy = "Information Technology",
                    FieldOfStudyAbbrev = "IT",
                    School = "Cebu Technological University",
                    Enrolled = new DateTime(2015, 5, 1),
                    Graduated = new DateTime(2019, 6, 1)
                },
            ]);
    }

    public override void Down()
    {
        Delete.FromTable("ProfileEducation")
            .Row(new { ProfileId = 1 });
    }
}
