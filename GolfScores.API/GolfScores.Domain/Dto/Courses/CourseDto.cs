using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfScores.Domain.Dto.Courses
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Par { get; set; }
        public List<Hole> Holes { get; set; }
    }
}
