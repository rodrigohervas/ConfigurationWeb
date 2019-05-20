using Microsoft.EntityFrameworkCore.Migrations;

namespace Configuration.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationValues",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationValues", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "ConfigurationValues",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "http", "http://localhost:5000" },
                    { "Complex:Department:Marketing", "Marketing and Sales Department" },
                    { "Complex:Department:Purchasing", "Purchasing Department" },
                    { "Complex:Department:Research", "Research and Development Department" },
                    { "Complex:Department:Production", "Production Department" },
                    { "Complex:Address:Country", "France" },
                    { "Complex:Address:Zipcode", "75008" },
                    { "Complex:Address:City", "Paris" },
                    { "Complex:Address:Street", "Avenue des Champs - Élysées 49" },
                    { "Complex:DateOfDeath", "18 November 1922" },
                    { "Complex:Department:HumanResources", "Human Resources Management Department" },
                    { "Complex:DateOfBirth", "10 July 1871" },
                    { "Complex:Email", "marcelproust@france.fr" },
                    { "Complex:Name", "Marcel Proust" },
                    { "TestUserGuid", "d4acd337-5915-4e32-b978-6d216e8b0353" },
                    { "TestUser", "John Smith" },
                    { "sslPort", "44303" },
                    { "Open Ports", "2011, 2456, 8885" },
                    { "ASPNETCORE_ENVIRONMENT", "Development" },
                    { "ConfigurationConnectionStringDB", "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EFConfigurationDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False" },
                    { "https", "https://localhost:5001" },
                    { "Complex:Position", "Writer" },
                    { "Complex:Department:Finance", "Accounting and Finance Department" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationValues");
        }
    }
}
