using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfScores.DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Golfers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Handicap = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Par = table.Column<int>(type: "int", nullable: false),
                    HandicapIndex = table.Column<int>(type: "int", nullable: false),
                    Yardage = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GolferId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Scores_Golfers_GolferId",
                        column: x => x.GolferId,
                        principalTable: "Golfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoleScores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GolferPlayingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CoursePlayedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HolePlayedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScoreOnHole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoleScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoleScores_Courses_CoursePlayedId",
                        column: x => x.CoursePlayedId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoleScores_Golfers_GolferPlayingId",
                        column: x => x.GolferPlayingId,
                        principalTable: "Golfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoleScores_Holes_HolePlayedId",
                        column: x => x.HolePlayedId,
                        principalTable: "Holes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Holes_CourseId",
                table: "Holes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_HoleScores_CoursePlayedId",
                table: "HoleScores",
                column: "CoursePlayedId");

            migrationBuilder.CreateIndex(
                name: "IX_HoleScores_GolferPlayingId",
                table: "HoleScores",
                column: "GolferPlayingId");

            migrationBuilder.CreateIndex(
                name: "IX_HoleScores_HolePlayedId",
                table: "HoleScores",
                column: "HolePlayedId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_GolferId",
                table: "Scores",
                column: "GolferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoleScores");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Holes");

            migrationBuilder.DropTable(
                name: "Golfers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
