using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(105, "create profile skills")]
public class Create_105_ProfileSkills : Migration
{
    public override void Up()
    {
        Create.Table("ProfileSkill")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProfileId").AsInt32().NotNullable()
            .WithColumn("Category").AsString(256).Nullable()
            .WithColumn("Name").AsString(256).Nullable()
            .WithColumn("Proficiency").AsFloat().NotNullable()
            .WithColumn("CreatedAt").AsDateTime2().Nullable();

        Create.ForeignKey("FK_ProfileSkill_Profile")
            .FromTable("ProfileSkill").ForeignColumn("ProfileId")
            .ToTable("Profile").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProfileSkill_Profile")
            .OnTable("ProfileSkill");
        Delete.Table("ProfileSkill");
    }
}