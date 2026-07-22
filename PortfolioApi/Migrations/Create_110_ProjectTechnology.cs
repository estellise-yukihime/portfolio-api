using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(110, "create project technology")]
public class Create_110_ProjectTechnology : Migration
{
    public override void Up()
    {
        Create.Table("ProjectTechnology")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProjectId").AsInt32().NotNullable()
            .WithColumn("Tech").AsString(256).Nullable();

        Create.ForeignKey("FK_ProjectTechnology_CareerProject")
            .FromTable("ProjectTechnology").ForeignColumn("ProjectId")
            .ToTable("CareerProject").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProjectTechnology_CareerProject")
            .OnTable("ProjectTechnology");
        Delete.Table("ProjectTechnology");
    }
}
