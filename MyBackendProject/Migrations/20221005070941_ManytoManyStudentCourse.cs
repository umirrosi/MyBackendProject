using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendProject.Migrations
{
    public partial class ManytoManyStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CourseID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_CourseStudent_courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "students",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentID",
                table: "CourseStudent",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");
        }
    }
}
