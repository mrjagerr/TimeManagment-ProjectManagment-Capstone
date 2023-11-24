using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37df1727-c655-4634-9615-2d867c7e9dd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1a11f2f-1433-4954-97fd-4e9c47504b4e");

            migrationBuilder.AddColumn<int>(
                name: "TotalHoursForSingleProject",
                table: "DailyProjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a5ad8ef-fa5d-4592-8df9-661dae1a4355", null, "User", "USER" },
                    { "a9d15cb4-1434-444c-8394-375b189cf8e0", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a5ad8ef-fa5d-4592-8df9-661dae1a4355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9d15cb4-1434-444c-8394-375b189cf8e0");

            migrationBuilder.DropColumn(
                name: "TotalHoursForSingleProject",
                table: "DailyProjects");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37df1727-c655-4634-9615-2d867c7e9dd3", null, "Admin", "ADMIN" },
                    { "a1a11f2f-1433-4954-97fd-4e9c47504b4e", null, "User", "USER" }
                });
        }
    }
}
