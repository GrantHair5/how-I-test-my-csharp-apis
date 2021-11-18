using System;

namespace GolfScores.DB.Entities
{
    public class Scores
    {
        public Guid Id { get; set; }
        
        public virtual Golfer Golfer { get; set; }

        public int TotalScore { get; set; }

    }
}
