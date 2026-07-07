using FluentMigrator;
using PortfolioApi.Entities;

namespace PortfolioApi.Migrations;

[Migration(1003, "insert hero for profile apply.estellise.caballero@gmail.com")]
public class Insert_1003_ProfileHero : Migration
{
    public override void Up()
    {
        Insert.IntoTable("ProfileHero")
            .Row(new ProfileHero
            {
                ProfileId = 1,
                Head = "I build <<text-primary,\"scalable,\">> <<text-secondary,\"reliable,\">> and <<text-accent,\"maintainable\">> systems",
                Text = "A .NET Developer with 7+ years of experience designing, developing, and maintaining applications and services. <<line-through,\"I am lazy, I want to be rich, rich, rich!!!\">> Let me know your vision, and I'll show you the craft."
            });
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}