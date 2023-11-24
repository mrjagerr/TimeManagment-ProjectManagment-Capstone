using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e080ccec-4660-4531-a96a-80517737ecd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd719f2e-2782-4ba1-b7ba-7c540e233386");

            migrationBuilder.RenameColumn(
                name: "TeamMemberUsername",
                table: "Shifts",
                newName: "Username");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3709d413-1dff-4b15-af02-30779e1926d0", null, "User", "USER" },
                    { "8a25c524-93e1-48c3-8490-fc68a66f7c3c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3709d413-1dff-4b15-af02-30779e1926d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a25c524-93e1-48c3-8490-fc68a66f7c3c");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Shifts",
                newName: "TeamMemberUsername");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e080ccec-4660-4531-a96a-80517737ecd9", null, "User", "USER" },
                    { "fd719f2e-2782-4ba1-b7ba-7c540e233386", null, "Admin", "ADMIN" }
                });
        }
    }
}
