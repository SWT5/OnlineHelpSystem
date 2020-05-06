using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class SAnewKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AuId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AuId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    AuId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CourseFkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.AuId);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_CourseFkId",
                        column: x => x.CourseFkId,
                        principalTable: "Courses",
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
                        name: "FK_StudentCourse_Courses_CourseFKId",
                        column: x => x.CourseFKId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_StudentFKAuId",
                        column: x => x.StudentFKAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
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
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseFKId",
                        column: x => x.CourseFKId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers_TeacherFKId",
                        column: x => x.TeacherFKId,
                        principalTable: "Teachers",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Lecture = table.Column<string>(nullable: true),
                    HelpWhere = table.Column<string>(nullable: true),
                    CourseFKId = table.Column<int>(nullable: false),
                    StudentFKId = table.Column<string>(nullable: true),
                    TeacherFKId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_Exercises_Courses_CourseFKId",
                        column: x => x.CourseFKId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercises_Students_StudentFKId",
                        column: x => x.StudentFKId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Teachers_TeacherFKId",
                        column: x => x.TeacherFKId,
                        principalTable: "Teachers",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    StudentFKAuId = table.Column<string>(nullable: false),
                    AssignmentFKId = table.Column<int>(nullable: false),
                    StudentAssignmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => new { x.StudentFKAuId, x.AssignmentFKId });
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignments_AssignmentFKId",
                        column: x => x.AssignmentFKId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Students_StudentFKAuId",
                        column: x => x.StudentFKAuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Name" },
                values: new object[,]
                {
                    { 111, "DAB" },
                    { 222, "GUI" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "AuId", "Name" },
                values: new object[,]
                {
                    { "1", "Thanh" },
                    { "2", "Nikolaj" },
                    { "3", "Mads" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "AuId", "CourseFkId", "Name" },
                values: new object[] { "123456", 111, "Jens" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "AuId", "CourseFkId", "Name" },
                values: new object[] { "654321", 222, "Poul" });

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
                columns: new[] { "ExerciseId", "CourseFKId", "HelpWhere", "Lecture", "Number", "StudentFKId", "TeacherFKId" },
                values: new object[,]
                {
                    { 1, 111, "bord 3", "1", 1, "3", "123456" },
                    { 2, 111, "bord 5", "2", 1, "2", "123456" },
                    { 3, 222, "bord 19", "3", 1, "1", "123456" },
                    { 4, 222, "bord 7", "4", 1, "2", "654321" },
                    { 5, 222, "bord 7", "5", 1, "3", "654321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseFKId",
                table: "Assignments",
                column: "CourseFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherFKId",
                table: "Assignments",
                column: "TeacherFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CourseFKId",
                table: "Exercises",
                column: "CourseFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_StudentFKId",
                table: "Exercises",
                column: "StudentFKId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TeacherFKId",
                table: "Exercises",
                column: "TeacherFKId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentFKId",
                table: "StudentAssignment",
                column: "AssignmentFKId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseFKId",
                table: "StudentCourse",
                column: "CourseFKId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentFKAuId",
                table: "StudentCourse",
                column: "StudentFKAuId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseFkId",
                table: "Teachers",
                column: "CourseFkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
