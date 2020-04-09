using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class insterDummyExerciseAssigmnet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "AssignmentName", "AssignmentNumber", "CourseFKId", "TeacherFKId" },
                values: new object[,]
                {
                    { 1, "DAB handin 1", "1", 111, "654321" },
                    { 2, "DAB handin 2", "2", 111, "654321" }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Lecture", "Number", "CourseFKId", "HelpWhere", "StudentFKId", "TeacherFKId" },
                values: new object[,]
                {
                    { "2", 1, 111, "bord 5", "2", "123456" },
                    { "3", 1, 222, "bord 19", "1", "123456" },
                    { "4", 1, 222, "bord 7", "2", "654321" },
                    { "5", 1, 222, "bord 7", "3", "654321" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "AssignmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumns: new[] { "Lecture", "Number" },
                keyValues: new object[] { "2", 1 });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumns: new[] { "Lecture", "Number" },
                keyValues: new object[] { "3", 1 });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumns: new[] { "Lecture", "Number" },
                keyValues: new object[] { "4", 1 });

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumns: new[] { "Lecture", "Number" },
                keyValues: new object[] { "5", 1 });
        }
    }
}
