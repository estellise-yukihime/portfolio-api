using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(109, "create project image")]
public class Create_109_ProjectImage : Migration
{
    public override void Up()
    {
        Create.Table("ProjectImage")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProjectId").AsInt32().NotNullable()
            .WithColumn("Imij").AsString(256).Nullable();

        Create.ForeignKey("FK_ProjectImage_CareerProject")
            .FromTable("ProjectImage").ForeignColumn("ProjectId")
            .ToTable("CareerProject").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProjectImage_CareerProject")
            .OnTable("ProjectImage");
        Delete.Table("ProjectImage");
    }
}
