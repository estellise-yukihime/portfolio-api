using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(103, "create profile hero")]
public class Create_103_ProfileHero : Migration
{
    public override void Up()
    {
        Create.Table("ProfileHero")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProfileId").AsInt32().NotNullable()
            .WithColumn("Head").AsString(1024).Nullable()
            .WithColumn("Text").AsString(1024).Nullable();

        Create.ForeignKey("FK_ProfileHero_Profile")
            .FromTable("ProfileHero").ForeignColumn("ProfileId")
            .ToTable("Profile").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProfileHero_Profile")
            .OnTable("ProfileHero");
        Delete.Table("ProfileHero");
    }
}