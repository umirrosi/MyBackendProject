using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendProject.Migrations
{
    public partial class SPgetallenrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.GetAllWithQuery
               AS
               SELECT      Enrollment.EnrollmentID, Enrollment.StudentID, Enrollment.CourseID, Enrollment.Grade
               FROM        Enrollment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop procedure GetAllWithQuery");
        }
    }
}
