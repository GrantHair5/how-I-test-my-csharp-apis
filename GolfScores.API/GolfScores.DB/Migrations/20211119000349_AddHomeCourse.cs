using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfScores.DB.Migrations
{
    public partial class AddHomeCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HomeCourseId",
                table: "Golfers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Golfers_HomeCourseId",
                table: "Golfers",
                column: "HomeCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Golfers_Courses_HomeCourseId",
                table: "Golfers",
                column: "HomeCourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Golfers_Courses_HomeCourseId",
                table: "Golfers");

            migrationBuilder.DropIndex(
                name: "IX_Golfers_HomeCourseId",
                table: "Golfers");

            migrationBuilder.DropColumn(
                name: "HomeCourseId",
                table: "Golfers");
        }
    }
}
