﻿using System.Collections.Generic;
using GolfScores.Domain.Dto.Courses;

namespace GolfScores.Services
{
    public interface ICourseDataIntegrationServices
    {
        List<CourseDto> GetAllCourses();
    }
}
