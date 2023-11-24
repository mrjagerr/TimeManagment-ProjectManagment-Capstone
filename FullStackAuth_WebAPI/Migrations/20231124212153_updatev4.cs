using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatev4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a5ad8ef-fa5d-4592-8df9-661dae1a4355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9d15cb4-1434-444c-8394-375b189cf8e0");

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectDate",
                table: "Zones",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectDate",
                table: "PriorityFills",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectDate",
                table: "OutOfStocks",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectDate",
                table: "DailyProjects",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49cd51b6-dcb6-4815-8bd2-f341ffa8de51", null, "Admin", "ADMIN" },
                    { "990cfe9a-f780-4d63-b9dd-c2390468d83f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49cd51b6-dcb6-4815-8bd2-f341ffa8de51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "990cfe9a-f780-4d63-b9dd-c2390468d83f");

            migrationBuilder.DropColumn(
                name: "ProjectDate",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "ProjectDate",
                table: "PriorityFills");

            migrationBuilder.DropColumn(
                name: "ProjectDate",
                table: "OutOfStocks");

            migrationBuilder.DropColumn(
                name: "ProjectDate",
                table: "DailyProjects");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a5ad8ef-fa5d-4592-8df9-661dae1a4355", null, "User", "USER" },
                    { "a9d15cb4-1434-444c-8394-375b189cf8e0", null, "Admin", "ADMIN" }
                });
        }
    }
}
