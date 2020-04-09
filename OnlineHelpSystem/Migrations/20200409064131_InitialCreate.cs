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
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Name = table.Column<string>(nullable: true),
                    CourseFKId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.AuId);
                    table.ForeignKey(
                        name: "FK_Teacher_Course_CourseFKId",
                        column: x => x.CourseFKId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentCourseId = table.Column<string>(nullable: false),
                    CourseFKId = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    StudentFKAuId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.StudentCourseId);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseFKId",
                        column: x => x.CourseFKId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Student_StudentFKAuId",
                        column: x => x.StudentFKAuId,
                        principalTable: "Student",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentName = table.Column<string>(nullable: true),
                    AssignmentNumber = table.Column<string>(nullable: true),
                    TeacherFKId = table.Column<string>(nullable: true),
                    CourseFKId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignment_Course_CourseFKId",
                        column: x => x.CourseFKId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Teacher_TeacherFKId",
                        column: x => x.TeacherFKId,
                        principalTable: "Teacher",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false),
                    Lecture = table.Column<string>(nullable: false),
                    HelpWhere = table.Column<string>(nullable: true),
                    CourseFKId = table.Column<int>(nullable: false),
                    StudentFKId = table.Column<string>(nullable: true),
                    TeacherFKId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => new { x.Lecture, x.Number });
                    table.ForeignKey(
                        name: "FK_Exercise_Course_CourseFKId",
                        column: x => x.CourseFKId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Student_StudentFKId",
                        column: x => x.StudentFKId,
                        principalTable: "Student",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Teacher_TeacherFKId",
                        column: x => x.TeacherFKId,
                        principalTable: "Teacher",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentAssignmentId = table.Column<string>(nullable: false),
                    StudentFKAuId = table.Column<string>(nullable: true),
                    AssignmentFKId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => x.StudentAssignmentId);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignment_AssignmentFKId",
                        column: x => x.AssignmentFKId,
                        principalTable: "Assignment",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Student_StudentFKAuId",
                        column: x => x.StudentFKAuId,
                        principalTable: "Student",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_CourseFKId",
                table: "Assignment",
                column: "CourseFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_TeacherFKId",
                table: "Assignment",
                column: "TeacherFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_CourseFKId",
                table: "Exercise",
                column: "CourseFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_StudentFKId",
                table: "Exercise",
                column: "StudentFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_TeacherFKId",
                table: "Exercise",
                column: "TeacherFKId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentFKId",
                table: "StudentAssignment",
                column: "AssignmentFKId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_StudentFKAuId",
                table: "StudentAssignment",
                column: "StudentFKAuId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseFKId",
                table: "StudentCourse",
                column: "CourseFKId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentFKAuId",
                table: "StudentCourse",
                column: "StudentFKAuId");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_CourseFKId",
                table: "Teacher",
                column: "CourseFKId");
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
