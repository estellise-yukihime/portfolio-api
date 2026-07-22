using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(1009, "insert project images for default profile")]
public class Insert_1009_ProjectImage : Migration
{
    public override void Up()
    {
        Insert.IntoTable("ProjectImage")
            .Rows([
                // 5 - Card Program Management Portal
                new
                {
                    ProjectId = 5,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/03WorJDF.jpg"
                },
                new
                {
                    ProjectId = 5,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/eySBU8cT.jpg"
                },

                // 7 - Card Management Portal Platform
                new
                {
                    ProjectId = 7,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/7IH2oIWz.jpg"
                },
                new
                {
                    ProjectId = 7,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/9yp22aP_.jpg"
                },
                new
                {
                    ProjectId = 7,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/sve3EIEL.jpg"
                },
                new
                {
                    ProjectId = 7,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/-M3bABXE.jpg"
                },

                // 12 - Educational Battle Game
                new
                {
                    ProjectId = 12,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/es.jpg"
                },
                new
                {
                    ProjectId = 12,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/wc.jpg"
                },

                // 13 - Hyper-Casual Games
                new
                {
                    ProjectId = 13,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/se.jpg"
                },
                new
                {
                    ProjectId = 13,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/nb.jpg"
                },

                // 14 - Exam Test Application
                new
                {
                    ProjectId = 14,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/ai.jpg"
                },
                new
                {
                    ProjectId = 14,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/cs.jpg"
                },
                new
                {
                    ProjectId = 14,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/ge.jpg"
                },
                new
                {
                    ProjectId = 14,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/is.jpg"
                },
                new
                {
                    ProjectId = 14,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/os.jpg"
                },
                new
                {
                    ProjectId = 14,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/tk.jpg"
                },
                new
                {
                    ProjectId = 14,
                    Imij = "https://profile.r2.carlocaballero.com/imijs/projeks/uni.jpg"
                }
            ]);
    }

    public override void Down()
    {
        Delete.FromTable("ProjectImage")
            .AllRows();
    }
}
