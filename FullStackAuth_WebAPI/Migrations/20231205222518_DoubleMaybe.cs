using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DoubleMaybe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AlterColumn<double>(
                name: "PercentCompleted",
                table: "Projects",
                type: "double",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<int>(
                name: "PercentCompleted",
                table: "Projects",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

           
        }
    }
}
