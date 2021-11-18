using System;
using System.Collections.Generic;

namespace GolfScores.DB.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Hole> Holes { get; set; }
    }
}
