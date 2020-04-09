using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class intialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Course_CourseFKId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Teacher_TeacherFKId",
                table: "Assignment");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Course_CourseFKId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Student_StudentFKId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Teacher_TeacherFKId",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Assignment_AssignmentFKId",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Student_StudentFKAuId",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Course_CourseFKId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Student_StudentFKAuId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Course_CourseFKId",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "Assignment",
                newName: "Assignments");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_CourseFKId",
                table: "Teachers",
                newName: "IX_Teachers_CourseFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_TeacherFKId",
                table: "Exercises",
                newName: "IX_Exercises_TeacherFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_StudentFKId",
                table: "Exercises",
                newName: "IX_Exercises_StudentFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_CourseFKId",
                table: "Exercises",
                newName: "IX_Exercises_CourseFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_TeacherFKId",
                table: "Assignments",
                newName: "IX_Assignments_TeacherFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignment_CourseFKId",
                table: "Assignments",
                newName: "IX_Assignments_CourseFKId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "AuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "AuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                columns: new[] { "Lecture", "Number" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Courses_CourseFKId",
                table: "Assignments",
                column: "CourseFKId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Teachers_TeacherFKId",
                table: "Assignments",
                column: "TeacherFKId",
                principalTable: "Teachers",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Courses_CourseFKId",
                table: "Exercises",
                column: "CourseFKId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Students_StudentFKId",
                table: "Exercises",
                column: "StudentFKId",
                principalTable: "Students",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Teachers_TeacherFKId",
                table: "Exercises",
                column: "TeacherFKId",
                principalTable: "Teachers",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Assignments_AssignmentFKId",
                table: "StudentAssignment",
                column: "AssignmentFKId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Students_StudentFKAuId",
                table: "StudentAssignment",
                column: "StudentFKAuId",
                principalTable: "Students",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Courses_CourseFKId",
                table: "StudentCourse",
                column: "CourseFKId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Students_StudentFKAuId",
                table: "StudentCourse",
                column: "StudentFKAuId",
                principalTable: "Students",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseFKId",
                table: "Teachers",
                column: "CourseFKId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Courses_CourseFKId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Teachers_TeacherFKId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Courses_CourseFKId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Students_StudentFKId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Teachers_TeacherFKId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Assignments_AssignmentFKId",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssignment_Students_StudentFKAuId",
                table: "StudentAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Courses_CourseFKId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourse_Students_StudentFKAuId",
                table: "StudentCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseFKId",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "Assignment");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_CourseFKId",
                table: "Teacher",
                newName: "IX_Teacher_CourseFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_TeacherFKId",
                table: "Exercise",
                newName: "IX_Exercise_TeacherFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_StudentFKId",
                table: "Exercise",
                newName: "IX_Exercise_StudentFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_CourseFKId",
                table: "Exercise",
                newName: "IX_Exercise_CourseFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_TeacherFKId",
                table: "Assignment",
                newName: "IX_Assignment_TeacherFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_CourseFKId",
                table: "Assignment",
                newName: "IX_Assignment_CourseFKId");

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "AuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "AuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                columns: new[] { "Lecture", "Number" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignment",
                table: "Assignment",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Course_CourseFKId",
                table: "Assignment",
                column: "CourseFKId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Teacher_TeacherFKId",
                table: "Assignment",
                column: "TeacherFKId",
                principalTable: "Teacher",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Course_CourseFKId",
                table: "Exercise",
                column: "CourseFKId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Student_StudentFKId",
                table: "Exercise",
                column: "StudentFKId",
                principalTable: "Student",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Teacher_TeacherFKId",
                table: "Exercise",
                column: "TeacherFKId",
                principalTable: "Teacher",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Assignment_AssignmentFKId",
                table: "StudentAssignment",
                column: "AssignmentFKId",
                principalTable: "Assignment",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssignment_Student_StudentFKAuId",
                table: "StudentAssignment",
                column: "StudentFKAuId",
                principalTable: "Student",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Course_CourseFKId",
                table: "StudentCourse",
                column: "CourseFKId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourse_Student_StudentFKAuId",
                table: "StudentCourse",
                column: "StudentFKAuId",
                principalTable: "Student",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Course_CourseFKId",
                table: "Teacher",
                column: "CourseFKId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
