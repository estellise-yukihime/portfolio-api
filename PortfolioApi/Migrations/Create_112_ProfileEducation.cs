using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(112, "create profile education")]
public class Create_112_ProfileEducation : Migration
{
    public override void Up()
    {
        Create.Table("ProfileEducation")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProfileId").AsInt32().NotNullable()
            .WithColumn("Degree").AsString(256).Nullable()
            .WithColumn("DegreeAbbrev").AsString(256).Nullable()
            .WithColumn("FieldOfStudy").AsString(256).Nullable()
            .WithColumn("FieldOfStudyAbbrev").AsString(256).Nullable()
            .WithColumn("School").AsString(256).Nullable()
            .WithColumn("Enrolled").AsDateTime2().Nullable()
            .WithColumn("Graduated").AsDateTime2().Nullable();

        Create.ForeignKey("FK_ProfileEducation_Profile")
            .FromTable("ProfileEducation").ForeignColumn("ProfileId")
            .ToTable("Profile").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProfileEducation_Profile")
            .OnTable("ProfileEducation");
        Delete.Table("ProfileEducation");
    }
}
