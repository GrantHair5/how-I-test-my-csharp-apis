using System.Collections.Generic;
using GolfScores.Domain.Dto.Courses;
using GolfScores.Services;
using Microsoft.AspNetCore.Mvc;

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
    }
}
