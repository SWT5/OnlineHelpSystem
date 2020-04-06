using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    AuId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.AuId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    AuId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.AuId);
                    table.ForeignKey(
                        name: "FK_Teacher_Course_AuId",
                        column: x => x.AuId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentCourseId = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    StudentAuId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.StudentCourseId);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentAuId",
                        column: x => x.StudentAuId,
                        principalTable: "Student",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_StudentCourseId",
                        column: x => x.StudentCourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<string>(nullable: false),
                    AssignmentName = table.Column<string>(nullable: true),
                    AssignmentNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Teacher_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Teacher",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Course_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false),
                    Lecture = table.Column<string>(nullable: false),
                    HelpWhere = table.Column<string>(nullable: true),
                    CourseExerciseId = table.Column<string>(nullable: true),
                    StudentExerciseId = table.Column<string>(nullable: true),
                    TeacherExerciseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => new { x.Lecture, x.Number });
                    table.ForeignKey(
                        name: "FK_Exercise_Course_CourseExerciseId",
                        column: x => x.CourseExerciseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Student_StudentExerciseId",
                        column: x => x.StudentExerciseId,
                        principalTable: "Student",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Teacher_TeacherExerciseId",
                        column: x => x.TeacherExerciseId,
                        principalTable: "Teacher",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentAssignmentId = table.Column<string>(nullable: false),
                    StudentAuId = table.Column<string>(nullable: true),
                    AssignmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => x.StudentAssignmentId);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Student_StudentAuId",
                        column: x => x.StudentAuId,
                        principalTable: "Student",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_CourseExerciseId",
                table: "Exercise",
                column: "CourseExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_StudentExerciseId",
                table: "Exercise",
                column: "StudentExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TeacherExerciseId",
                table: "Exercise",
                column: "TeacherExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentId",
                table: "StudentAssignment",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_StudentAuId",
                table: "StudentAssignment",
                column: "StudentAuId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentAuId",
                table: "StudentCourse",
                column: "StudentAuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
