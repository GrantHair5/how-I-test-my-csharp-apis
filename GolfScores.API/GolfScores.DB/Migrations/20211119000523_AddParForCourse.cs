using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfScores.DB.Migrations
{
    public partial class AddParForCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Par",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Par",
                table: "Courses");
        }
    }
}
