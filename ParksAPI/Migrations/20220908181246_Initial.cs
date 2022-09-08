using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    State = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Name", "State", "Type" },
                values: new object[,]
                {
                    { 1, "Yosemite", "California", "National" },
                    { 2, "Big Basin Redwoods", "California", "National" },
                    { 3, "Yellowstone", "Montana", "National" },
                    { 4, "Bridal Veil Falls", "Oregon", "State" },
                    { 5, "Crater Lake National Park", "Oregon", "National" },
                    { 6, "Lime Kiln Point", "Washington", "State" },
                    { 7, "Eagle Island Marine", "Washington", "State" },
                    { 8, "Otter Point", "Oregon", "State" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
