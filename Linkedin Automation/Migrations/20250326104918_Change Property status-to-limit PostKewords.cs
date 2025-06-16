using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Linkedin_Automation.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertystatustolimitPostKewords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PostKeywords");

            migrationBuilder.AddColumn<int>(
                name: "limit",
                table: "PostKeywords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "limit",
                table: "PostKeywords");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PostKeywords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
