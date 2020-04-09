using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class insertDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseFKId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "CourseFKId",
                table: "Teachers",
                newName: "CourseFkId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_CourseFKId",
                table: "Teachers",
                newName: "IX_Teachers_CourseFkId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseFkId",
                table: "Teachers",
                column: "CourseFkId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseFkId",
                table: "Teachers");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "AuId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "AuId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "AuId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "AuId",
                keyValue: "123456");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "AuId",
                keyValue: "654321");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 222);

            migrationBuilder.RenameColumn(
                name: "CourseFkId",
                table: "Teachers",
                newName: "CourseFKId");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_CourseFkId",
                table: "Teachers",
                newName: "IX_Teachers_CourseFKId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseFKId",
                table: "Teachers",
                column: "CourseFKId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
