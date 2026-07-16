using FluentMigrator;
using PortfolioApi.Entities;

namespace PortfolioApi.Migrations;

// Format: Migration number from 1000+ and 1500 is insertion, update, and deletion or records
[Migration(1001, "insert default user")]
public class Insert_1001_User : Migration
{
    public override void Up()
    {
        Insert.IntoTable("User")
            .Row(new
            {
                Email = "estellise.caballero@gmail.com",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });
    }

    public override void Down()
    {
        Delete.FromTable("User")
            .Row(new
            {
                Email = "estellise.caballero@gmail.com"
            });
    }
}