using System;
using System.Collections.Generic;
using System.Linq;
using GolfScores.Domain.Dto.Courses;
using GolfScores.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace GolfScores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly ICourseDataIntegrationServices _courseDataIntegrationServices;

        public CoursesController(ICourseDataIntegrationServices courseDataIntegrationServices)
        {
            _courseDataIntegrationServices = courseDataIntegrationServices;
        }

        [HttpGet]
        public ActionResult<List<CourseDto>> Get()
        {
            return _courseDataIntegrationServices.GetAllCourses();
        }

        [HttpGet]
        [Route("Course")]
        public ActionResult<CourseDto> GetCourse(Guid id)
        {
            return _courseDataIntegrationServices.GetCourseById(id);
        }

    }
}
