using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfProjectModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "PercentCompleted",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "PercentCompleted",
                table: "Projects");

            
        }
    }
}
