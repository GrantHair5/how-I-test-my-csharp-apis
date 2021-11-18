using System;

namespace GolfScores.DB.Entities
{
    public class Hole
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public int Par { get; set; }
        public int HandicapIndex { get; set; }
        public int Yardage { get; set; }
        
    }
}
