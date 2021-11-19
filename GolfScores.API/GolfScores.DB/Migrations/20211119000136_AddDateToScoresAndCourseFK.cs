using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfScores.DB.Migrations
{
    public partial class AddDateToScoresAndCourseFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Scores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeOfScore",
                table: "Scores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Scores_CourseId",
                table: "Scores",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Courses_CourseId",
                table: "Scores",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Courses_CourseId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_CourseId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "DateTimeOfScore",
                table: "Scores");
        }
    }
}
