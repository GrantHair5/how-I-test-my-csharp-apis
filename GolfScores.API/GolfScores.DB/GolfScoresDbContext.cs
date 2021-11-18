using GolfScores.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace GolfScores.DB
{
    public class GolfScoresDbContext : DbContext
    {
        public GolfScoresDbContext(DbContextOptions<GolfScoresDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HoleScore> HoleScores { get; set; }
        public DbSet<Scores> Scores { get; set; }
    }
}
