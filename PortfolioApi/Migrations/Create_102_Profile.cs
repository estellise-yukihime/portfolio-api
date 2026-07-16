using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(102, "Create profile table")]
public class Create_102_Profile : Migration
{
    public override void Up()
    {
        Create.Table("Profile")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ExternalId").AsString(36).NotNullable()
            .WithColumn("UserId").AsInt32().NotNullable()
            .WithColumn("FirstName").AsString(256).Nullable()
            .WithColumn("LastName").AsString(256).Nullable()
            .WithColumn("Email").AsString(256).Nullable()
            .WithColumn("Photo").AsString(256).Nullable()
            .WithColumn("Title").AsString(256).Nullable()
            .WithColumn("Stack").AsString(256).Nullable()
            .WithColumn("State").AsString(256).Nullable()
            .WithColumn("About").AsString(int.MaxValue).Nullable()
            .WithColumn("Summary").AsString(int.MaxValue).Nullable()
            .WithColumn("CreatedAt").AsDateTime2().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime2().NotNullable();

        Create.ForeignKey("FK_Profile_User")
            .FromTable("Profile").ForeignColumn("UserId")
            .ToTable("User").PrimaryColumn("Id");

        Create.UniqueConstraint("UC_Profile_ExternalId")
            .OnTable("Profile")
            .Column("ExternalId");

        Create.UniqueConstraint("UC_Profile_Email")
            .OnTable("Profile")
            .Column("Email");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_Profile_User")
            .OnTable("Profile");
        Delete.UniqueConstraint("UC_Profile_ExternalId")
            .FromTable("Profile");
        Delete.UniqueConstraint("UC_Profile_Email")
            .FromTable("Profile");
        Delete.Table("Profile");
    }
}