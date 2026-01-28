using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(202601281, "Create profile table")]
public class CreateProfile : Migration
{
    public override void Up()
    {
        Create.Table("Profile")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("UserId").AsInt32().NotNullable()
            .WithColumn("ImgUrl").AsString(2048).Nullable()
            .WithColumn("Summary").AsString(int.MaxValue).Nullable()
            .WithColumn("FirstName").AsString(256).Nullable()
            .WithColumn("LastName").AsString(256).Nullable()
            .WithColumn("Email").AsString(320).Nullable()
            .WithColumn("PhoneNumber").AsString(32).Nullable();

        Create.Index("IX_Profile_UserId")
            .OnTable("Profile")
            .OnColumn("UserId").Ascending();
    }

    public override void Down()
    {
        Delete.Index("IX_Profile_UserId")
            .OnTable("Profile");
        Delete.Table("Profile");
    }
}