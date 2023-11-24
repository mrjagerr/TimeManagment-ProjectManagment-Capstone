using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoleFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "696dabca-8cf2-47ee-8d4d-06358b3ccc91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86938b3a-9eea-4ac5-a376-185d1d6bf69f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e080ccec-4660-4531-a96a-80517737ecd9", null, "User", "USER" },
                    { "fd719f2e-2782-4ba1-b7ba-7c540e233386", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e080ccec-4660-4531-a96a-80517737ecd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd719f2e-2782-4ba1-b7ba-7c540e233386");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "696dabca-8cf2-47ee-8d4d-06358b3ccc91", null, "Admin", "ADMIN" },
                    { "86938b3a-9eea-4ac5-a376-185d1d6bf69f", null, "User", "USER" }
                });
        }
    }
}
