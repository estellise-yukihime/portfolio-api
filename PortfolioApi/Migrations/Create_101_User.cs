using FluentMigrator;

namespace PortfolioApi.Migrations;

// note
//  format: 100+ table creation
[Migration(101, "Create user table")]
public class Create_101_User : Migration
{
    public override void Up()
    {
        Create.Table("User")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("Email").AsString(256).Nullable()
            .WithColumn("CreatedAt").AsDateTime2().NotNullable()
            .WithColumn("UpdatedAt").AsDateTime2().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("User");
    }
}