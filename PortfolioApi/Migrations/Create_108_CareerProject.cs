using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(108, "create career project")]
public class Create_108_CareerProject : Migration
{
    public override void Up()
    {
        Create.Table("CareerProject")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("CareerId").AsInt32().NotNullable()
            .WithColumn("Title").AsString(256).Nullable()
            .WithColumn("Description").AsString(int.MaxValue).Nullable()
            .WithColumn("Significance").AsFloat().NotNullable();

        Create.ForeignKey("FK_CareerProject_ProfileCareer")
            .FromTable("CareerProject").ForeignColumn("CareerId")
            .ToTable("ProfileCareer").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_CareerProject_ProfileCareer")
            .OnTable("CareerProject");
        Delete.Table("CareerProject");
    }
}
