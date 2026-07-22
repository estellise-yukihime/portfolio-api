using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(111, "create profile certificate")]
public class Create_111_ProfileCertificate : Migration
{
    public override void Up()
    {
        Create.Table("ProfileCertificate")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ProfileId").AsInt32().NotNullable()
            .WithColumn("Name").AsString(256).Nullable()
            .WithColumn("Issuer").AsString(256).Nullable()
            .WithColumn("Proof").AsString(256).Nullable()
            .WithColumn("IssuedAt").AsDateTime2().Nullable();

        Create.ForeignKey("FK_ProfileCertificate_Profile")
            .FromTable("ProfileCertificate").ForeignColumn("ProfileId")
            .ToTable("Profile").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("FK_ProfileCertificate_Profile")
            .OnTable("ProfileCertificate");
        Delete.Table("ProfileCertificate");
    }
}
