using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendProject.Migrations
{
    public partial class store_proc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.GetStudentByCourseID
               @CourseID int
               AS
               SELECT      students.ID, students.LastName, students.FirstMidName
               FROM        students INNER JOIN
                           Enrollment ON students.ID = Enrollment.StudentID
               WHERE       Enrollment.CourseID=@CourseID");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.GetCourseByStudentID
               @StudentID int
               AS
               SELECT      courses.CourseID, courses.Title, courses.Credits
               FROM        courses INNER JOIN
                           Enrollment ON courses.CourseID = Enrollment.CourseID
               WHERE       Enrollment.StudentID=@StudentID");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.DeleteEnrollmentForCourse
             @CourseID int
             AS
             DELETE FROM Enrollment
             WHERE Enrollment.CourseID=@CourseID");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.DeleteEnrollmentForStudent
             @StudentID int
             AS
             DELETE FROM Enrollment
             WHERE Enrollment.StudentID=@StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop procedure GetStudentByCourseID");
            migrationBuilder.Sql(@"drop procedure GetCourseByStudentID");
            migrationBuilder.Sql(@"drop procedure DeleteEnrollmentForCourse");
            migrationBuilder.Sql(@"drop procedure DeleteEnrollmentForStudent");
        }
    }
}
