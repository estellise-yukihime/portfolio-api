using FluentMigrator;

namespace PortfolioApi.Migrations;

[Migration(1008, "insert career projects for default profile")]
public class Insert_1008_CareerProject : Migration
{
    public override void Up()
    {
        Insert.IntoTable("CareerProject")
            .Rows([
                // Full Scale
                new
                {
                    Id = 1,
                    CareerId = 1,
                    Title = "SetldPay CI/CD Pipeline",
                    Description = """
                                  I designed and implemented the CI/CD pipeline for SetldPay using GitHub Actions to 
                                  automate checks, builds, tests, and deployment workflows across websites, web APIs, 
                                  and services to Azure servers.
                                  """,
                    Significance = 0.85f
                },
                new
                {
                    Id = 2,
                    CareerId = 1,
                    Title = "InComm Integration API",
                    Description = """
                                  I designed and developed the integration layer between InComm and the 
                                  SetldPay Card Program, processing transaction events. 
                                  I architected the transaction processing around a clean, extensible pattern mapping 
                                  incoming InComm message types to dedicated handlers, secured with JWT authentication 
                                  and policy-based authorization.
                                  """,
                    Significance = 0.9f
                },
                new
                {
                    Id = 3,
                    CareerId = 1,
                    Title = "Banking Integration API",
                    Description = """
                                  I designed and developed an API following clean architecture principles that serves
                                   as the integration layer between SetldPay's internal applications and third-party 
                                   banking providers. 
                                   It manages bank account onboarding, funding, and internal/external transfers while 
                                   abstracting each banking implementation behind a standard interface, 
                                   secured via custom HMAC-based authentication.
                                  """,
                    Significance = 0.95f
                },
                new
                {
                    Id = 4,
                    CareerId = 1,
                    Title = "Card Program Management API",
                    Description = """
                                  I developed and maintained the API powering the card program management portal, 
                                  enabling internal operations teams to manage physical and virtual cards, 
                                  transactions, fundings, and programs. 
                                  I'm responsible for the the API's architecture, feature development, 
                                  bug fixes, and test coverage.
                                  """,
                    Significance = 0.9f
                },
                new
                {
                    Id = 5,
                    CareerId = 1,
                    Title = "Card Program Management Portal",
                    Description = """
                                  I collaborated with a team of three developers to build an internal operations 
                                  dashboard that lets support staff, client managers, and administrators oversee 
                                  physical & virtual cards, fundings, card details, and card designs. 
                                  I focus on implementing features aligned with business requirements, bug fixes, 
                                  test coverage and collaborating with the team to improve the application.
                                  """,
                    Significance = 0.7f
                },
                new
                {
                    Id = 6,
                    CareerId = 1,
                    Title = "Card Management APIs",
                    Description = """
                                  I designed and developed the API powering multiple physical & virtual card management 
                                  portals across partners, architected around a shared base API that partner-specific 
                                  APIs inherit from — enabling new partner APIs to be spun up quickly. 
                                  Features include card lookup, KYC verification and screening, card linking, 
                                  PIN/ACS management, transaction history, and user/profile management.
                                  """,
                    Significance = 0.9f
                },
                new
                {
                    Id = 7,
                    CareerId = 1,
                    Title = "Card Management Portal",
                    Description = """
                                  I collaborated with a team of three developers to architect a plug-and-play platform 
                                  for physical & virtual card management portals, centralizing common services, 
                                  reusable components, utilities, and business logic into a single source of truth 
                                  for rapid development and deployment across partners.
                                  """,
                    Significance = 0.7f
                },
                new
                {
                    Id = 8,
                    CareerId = 1,
                    Title = "Standalone .NET Services",
                    Description = """
                                  I developed standalone .NET services that streamline core business 
                                  operations — including XML data extraction, image batch uploading, web scraping, 
                                  high-throughput webhook processing (thousands of records per minute), 
                                  and automated SMS/email client notifications.
                                  """,
                    Significance = 0.7f
                },
                new
                {
                    Id = 9,
                    CareerId = 1,
                    Title = "Heavy Machinery Dealer APIs",
                    Description = """
                                  I collaborated with a senior developer and senior architect to develop web APIs 
                                  for heavy machinery products using .NET Web API and SQL Server, enabling platform 
                                  integration for partner and third-party dealers.
                                  """,
                    Significance = 0.8f
                },
                new
                {
                    Id = 10,
                    CareerId = 1,
                    Title = "Heavy Machinery Management App",
                    Description = """
                                  I collaborated with a team of four developers to build and maintain a web application 
                                  for managing new and pre-owned heavy machinery, featuring detailed machine listings, 
                                  a booking system, and tools for generating quotes, brochures, and reports.
                                  """,
                    Significance = 0.7f
                },
                new
                {
                    Id = 11,
                    CareerId = 1,
                    Title = "Heavy Machinery Parts E-Commerce",
                    Description = """
                                  I developed an e-commerce web application for selling heavy machinery parts, featuring 
                                  product listings with advanced filtering, a mailing writer and sender, 
                                  mailing notifications, product management, and a seamless payment flow.
                                  """,
                    Significance = 0.65f
                },

                // FreCre, Inc
                new
                {
                    Id = 12,
                    CareerId = 2,
                    Title = "Educational Battle Game",
                    Description = """
                                  I maintained and developed an educational battle game for Japanese clients, 
                                  implementing features such as battle and leveling systems, a stage system, 
                                  an event reward system, social networking, messaging, notifications, 
                                  in-app purchases, and subscription services.
                                  """,
                    Significance = 0.87f
                },
                new
                {
                    Id = 13,
                    CareerId = 2,
                    Title = "Hyper-Casual Games",
                    Description = """
                                  I developed hyper-casual mobile games in collaboration with Japanese clients and teams, 
                                  building game systems and content with Unity3D and C#.
                                  """,
                    Significance = 0.6f
                },
                new
                {
                    Id = 14,
                    CareerId = 2,
                    Title = "Exam Test Application",
                    Description = """
                                  I maintained and developed a test application for high-school and college exams, 
                                  delivering features for exam delivery and content management.
                                  """,
                    Significance = 0.65f
                },
                new
                {
                    Id = 15,
                    CareerId = 2,
                    Title = "Game Content Management System",
                    Description = """
                                  I developed and maintained a game content management system and its supporting 
                                  back-end servers, using .NET, Java, and Python with Flask, 
                                  backed by Datastore for database management.
                                  """,
                    Significance = 0.85f
                },

                // Tudlo Innovation Solutions Inc
                new
                {
                    Id = 16,
                    CareerId = 3,
                    Title = "Member Networking System",
                    Description = """
                                  I maintained a member networking system, handling system maintenance, bug fixing, 
                                  planning, and feature implementation — most notably a visualization of a member 
                                  referral system and authentication/authorization mechanisms.
                                  """,
                    Significance = 0.6f
                },
                new
                {
                    Id = 17,
                    CareerId = 3,
                    Title = "E-Commerce Sub-Site",
                    Description = """
                                  I implemented an e-commerce sub-site with a complete checkout flow as part of the 
                                  networking platform.
                                  """,
                    Significance = 0.55f
                }
            ]);
    }

    public override void Down()
    {
        Delete.FromTable("CareerProject")
            .AllRows();
    }
}
