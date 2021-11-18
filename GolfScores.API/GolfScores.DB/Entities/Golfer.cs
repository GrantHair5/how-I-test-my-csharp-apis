using System;

namespace GolfScores.DB.Entities
{
    public class Golfer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Handicap { get; set; }
    }
}
