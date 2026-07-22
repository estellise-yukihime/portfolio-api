using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(107, "create profile career")]
public class Create_107_ProfileCareer : Migration
{
    public override void Up()
    {
        Create.Table("ProfileCareer")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProfileId").AsInt32().NotNullable()
            .WithColumn("Name").AsString(256).Nullable()
            .WithColumn("Position").AsString(256).Nullable()
            .WithColumn("Joined").AsDateTime2().Nullable()
            .WithColumn("Leaved").AsDateTime2().Nullable();

        Create.ForeignKey("FK_ProfileCareer_Profile")
            .FromTable("ProfileCareer").ForeignColumn("ProfileId")
            .ToTable("Profile").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProfileCareer_Profile")
            .OnTable("ProfileCareer");
        Delete.Table("ProfileCareer");
    }
}
