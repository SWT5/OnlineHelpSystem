using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class insertDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "AuId", "CourseFKId", "Name" },
                values: new object[,]
                {
                    { "123456", 0, "Jens" },
                    { "654321", 0, "Poul" },
                    { "246810", 0, "Susanne" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 222);

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
                keyValue: "246810");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "AuId",
                keyValue: "654321");
        }
    }
}
