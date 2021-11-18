using System;

namespace GolfScores.DB.Entities
{
    public class HoleScore
    {
        public Guid Id { get; set; }
        public virtual Golfer GolferPlaying { get; set; }
        public virtual Course CoursePlayed { get; set; }
        public virtual Hole HolePlayed { get; set; }
        public int ScoreOnHole { get; set; }
    }
}
