using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04baf19d-9916-424c-81ee-856f7a4c784b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "359636a3-6179-4419-9f94-b58f762371cc");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "PriorityFills");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "OutOfStocks");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Zones",
                type: "longtext",
                nullable: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "855ceeaf-f4b5-40fe-865e-84e241fd9185", null, "User", "USER" },
                    { "9ee6a069-95f3-47d5-891a-9504a7eca832", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "855ceeaf-f4b5-40fe-865e-84e241fd9185");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ee6a069-95f3-47d5-891a-9504a7eca832");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Zones");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Zones",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "PriorityFills",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "OutOfStocks",
                type: "longtext",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04baf19d-9916-424c-81ee-856f7a4c784b", null, "Admin", "ADMIN" },
                    { "359636a3-6179-4419-9f94-b58f762371cc", null, "User", "USER" }
                });
        }
    }
}
