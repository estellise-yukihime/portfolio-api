using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(106, "create profile cv")]
public class Create_106_ProfileCV : Migration
{
    public override void Up()
    {
        Create.Table("ProfileCV")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProfileId").AsInt32().NotNullable()
            .WithColumn("CV").AsString(256).Nullable()
            .WithColumn("CreatedAt").AsDateTime2().NotNullable();

        Create.ForeignKey("FK_ProfileCV_Profile")
            .FromTable("ProfileCV").ForeignColumn("ProfileId")
            .ToTable("Profile").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProfileCV_Profile")
            .OnTable("ProfileCV");
        Delete.Table("ProfileCV");
    }
}