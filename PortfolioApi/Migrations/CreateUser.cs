using FluentMigrator;

namespace PortfolioApi.Migrations;

// note
//  format: yyyymmdd[index]
//  index means the number of migration that was created that day
[Migration(20251224, "Create user table")]
public class CreateUser : Migration
{
    public override void Up()
    {
        Create.Table("User")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString(256).Nullable()
            .WithColumn("LastName").AsString(256).Nullable()
            .WithColumn("Username").AsString(256).Nullable()
            .WithColumn("Email").AsString(256).Nullable()
            .WithColumn("PhoneNumber").AsString(256).Nullable()
            .WithColumn("DateOfBirth").AsString(256).Nullable()
            .WithColumn("CreatedAt").AsString(256).Nullable()
            .WithColumn("UpdatedAt").AsString(256).Nullable();

    }

    public override void Down()
    {
        Delete.Table("User");
    }
}