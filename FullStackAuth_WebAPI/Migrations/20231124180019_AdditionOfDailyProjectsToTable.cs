using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdditionOfDailyProjectsToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aeb9ae-9f52-464c-a033-ed389b53eeb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ddf7ef-8747-4c1e-a3dd-55bb1845f61a");

            migrationBuilder.CreateTable(
                name: "DailyProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProjectName = table.Column<string>(type: "longtext", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    PriorityFillId = table.Column<int>(type: "int", nullable: false),
                    OutOfStocksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyProjects_OutOfStocks_OutOfStocksId",
                        column: x => x.OutOfStocksId,
                        principalTable: "OutOfStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyProjects_PriorityFills_PriorityFillId",
                        column: x => x.PriorityFillId,
                        principalTable: "PriorityFills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyProjects_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2654dcb7-b9ca-4030-95dd-127af4c88ead", null, "Admin", "ADMIN" },
                    { "f582a51e-6280-47b9-b7b4-c8d6f4a48f5e", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyProjects_OutOfStocksId",
                table: "DailyProjects",
                column: "OutOfStocksId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProjects_PriorityFillId",
                table: "DailyProjects",
                column: "PriorityFillId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyProjects_ZoneId",
                table: "DailyProjects",
                column: "ZoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyProjects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2654dcb7-b9ca-4030-95dd-127af4c88ead");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f582a51e-6280-47b9-b7b4-c8d6f4a48f5e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49aeb9ae-9f52-464c-a033-ed389b53eeb2", null, "User", "USER" },
                    { "f7ddf7ef-8747-4c1e-a3dd-55bb1845f61a", null, "Admin", "ADMIN" }
                });
        }
    }
}
