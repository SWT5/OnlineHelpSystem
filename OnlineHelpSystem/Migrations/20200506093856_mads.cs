using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class mads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "StudentAssignment");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Assignments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Assignments");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "StudentAssignment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
