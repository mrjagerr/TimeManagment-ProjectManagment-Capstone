using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProjects_OutOfStocks_OutOfStocksId",
                table: "DailyProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyProjects_PriorityFills_PriorityFillId",
                table: "DailyProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyProjects_Zones_ZoneId",
                table: "DailyProjects");

            migrationBuilder.DropIndex(
                name: "IX_DailyProjects_OutOfStocksId",
                table: "DailyProjects");

            migrationBuilder.DropIndex(
                name: "IX_DailyProjects_PriorityFillId",
                table: "DailyProjects");

            migrationBuilder.DropIndex(
                name: "IX_DailyProjects_ZoneId",
                table: "DailyProjects");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "543d5b8a-9b71-4aea-a368-0d7d45e9d13f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4624bc2-bc21-49eb-8967-207e031f89ac");

            migrationBuilder.DropColumn(
                name: "OutOfStocksId",
                table: "DailyProjects");

            migrationBuilder.DropColumn(
                name: "PriorityFillId",
                table: "DailyProjects");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "DailyProjects");

            migrationBuilder.AlterColumn<int>(
                name: "WorkloadValue",
                table: "Zones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37df1727-c655-4634-9615-2d867c7e9dd3", null, "Admin", "ADMIN" },
                    { "a1a11f2f-1433-4954-97fd-4e9c47504b4e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37df1727-c655-4634-9615-2d867c7e9dd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1a11f2f-1433-4954-97fd-4e9c47504b4e");

            migrationBuilder.AlterColumn<string>(
                name: "WorkloadValue",
                table: "Zones",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OutOfStocksId",
                table: "DailyProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityFillId",
                table: "DailyProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "DailyProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "543d5b8a-9b71-4aea-a368-0d7d45e9d13f", null, "User", "USER" },
                    { "c4624bc2-bc21-49eb-8967-207e031f89ac", null, "Admin", "ADMIN" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProjects_OutOfStocks_OutOfStocksId",
                table: "DailyProjects",
                column: "OutOfStocksId",
                principalTable: "OutOfStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProjects_PriorityFills_PriorityFillId",
                table: "DailyProjects",
                column: "PriorityFillId",
                principalTable: "PriorityFills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProjects_Zones_ZoneId",
                table: "DailyProjects",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
