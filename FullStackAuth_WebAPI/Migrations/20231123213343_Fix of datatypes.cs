using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixofdatatypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88eb0e4f-bd5a-413d-a46a-c5768007fa0c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6ca1f71-5da2-4044-b8ab-347e56f23d34");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "457f9b37-2704-4ff4-b252-51a784ffa614", null, "Admin", "ADMIN" },
                    { "ddbd8c31-8b25-4c09-b586-030cdf4a77bd", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "457f9b37-2704-4ff4-b252-51a784ffa614");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddbd8c31-8b25-4c09-b586-030cdf4a77bd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88eb0e4f-bd5a-413d-a46a-c5768007fa0c", null, "Admin", "ADMIN" },
                    { "f6ca1f71-5da2-4044-b8ab-347e56f23d34", null, "User", "USER" }
                });
        }
    }
}
