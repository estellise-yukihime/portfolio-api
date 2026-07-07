using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(104, "create profile socials")]
public class Create_104_ProfileSocial : Migration
{
    public override void Up()
    {
        Create.Table("ProfileSocial")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProfileId").AsInt32().NotNullable()
            .WithColumn("Name").AsString(256).Nullable()
            .WithColumn("Link").AsString(256).Nullable();

        Create.ForeignKey("FK_ProfileSocial_Profile")
            .FromTable("ProfileSocial").ForeignColumn("ProfileId")
            .ToTable("Profile").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProfileSocial_Profile")
            .OnTable("ProfileSocial");
        Delete.Table("ProfileSocial");
    }
}