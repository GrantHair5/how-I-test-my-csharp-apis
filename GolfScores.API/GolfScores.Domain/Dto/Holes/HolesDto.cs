using System;

namespace GolfScores.Domain.Dto.Holes
{
    public class HolesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Par { get; set; }
        public int HandicapIndex { get; set; }
        public int Yardage { get; set; }
    }
}
