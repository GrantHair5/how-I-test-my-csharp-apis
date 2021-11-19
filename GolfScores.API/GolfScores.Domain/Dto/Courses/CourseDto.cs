using GolfScores.Domain.Dto.Holes;
using System;
using System.Collections.Generic;

namespace GolfScores.Domain.Dto.Courses
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Par { get; set; }
        public List<HolesDto> Holes { get; set; }
    }
}
