using System.Collections.Generic;
using System.Linq;
using GolfScores.DB;
using GolfScores.Domain.Dto.Courses;
using GolfScores.Domain.Dto.Holes;
using Microsoft.EntityFrameworkCore;

namespace GolfScores.Services.Implementation
{
    public class CourseDataIntegrationServices : ICourseDataIntegrationServices
    {
        private readonly GolfScoresDbContext _context;

        public CourseDataIntegrationServices(GolfScoresDbContext context)
        {
            _context = context;
        }

        public List<CourseDto> GetAllCourses()
        {
            return _context
                .Courses
                .Include(x => x.Holes)
                .Select(x => new CourseDto
                {
                    Holes = x.Holes.Select(h => new HolesDto
                    {
                        Name = h.Name, 
                        HandicapIndex = h.HandicapIndex, 
                        Par = h.Par, 
                        Id = h.Id, 
                        Number = h.Number, 
                        Yardage = h.Yardage
                    }).OrderBy(h=>h.Number).ToList(), 
                    Id = x.Id, 
                    Name = x.Name, 
                    Par = x.Par
                })
                .ToList();
        }
    }
}