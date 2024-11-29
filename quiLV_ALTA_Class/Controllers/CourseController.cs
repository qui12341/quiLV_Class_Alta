using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Class;
using quiLV_ALTA_Class.Services.CourseService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<IEnumerable<Course>>> GetClass()
        {
            var courses = await _courseService.GetAllCourseAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Course>> CreateCourse(Course course)
        {
            await _courseService.CreateCourseAsync(course);
            return CreatedAtAction(nameof(GetCourse), new { id = course.Course_ID }, course);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            if (id != course.Course_ID)
            {
                return BadRequest();
            }

            await _courseService.UpdateCourseAsync(course);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteRole(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
