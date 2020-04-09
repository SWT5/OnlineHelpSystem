using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class insterDummyExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Lecture", "Number", "CourseFKId", "HelpWhere", "StudentFKId", "TeacherFKId" },
                values: new object[] { "1", 1, 111, "bord 3", "3", "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumns: new[] { "Lecture", "Number" },
                keyValues: new object[] { "1", 1 });
        }
    }
}
