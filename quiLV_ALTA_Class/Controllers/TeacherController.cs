using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.TeacherClassService;
using quiLV_ALTA_Class.Services.TeacherService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeacher()
        {
            var teacher = await _teacherService.GetAllTeacherAsync();
            return Ok(teacher);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Teacher>> CreateTeacher(Teacher teacher)
        {
            await _teacherService.CreateTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Teacher_Id }, teacher);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Teacher_Id)
            {
                return BadRequest();
            }

            await _teacherService.UpdateTeacherAsync(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            await _teacherService.DeleteTeacherAsync(id);
            return NoContent();
        }
    }
}
