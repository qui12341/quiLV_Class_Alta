using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Student_ClassService;
using quiLV_ALTA_Class.Services.TeacherClassService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeacherClassController : ControllerBase
    {
        private readonly ITeacherClassService _teacherClassService;
        public TeacherClassController(ITeacherClassService teacherClassService)
        {
            _teacherClassService = teacherClassService;
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<IEnumerable<Teacher_CLass>>> GetTeacherClass()
        {
            var teacher_CLasses = await _teacherClassService.GetAllTeacherClassAsync();
            return Ok(teacher_CLasses);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Teacher_CLass>> GetTeacherClass(int id)
        {
            var teacher_CLass = await _teacherClassService.GetTeacherClassByIdAsync(id);
            if (teacher_CLass == null)
            {
                return NotFound();
            }
            return Ok(teacher_CLass);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Teacher_CLass>> CreateTeacherClass(Teacher_CLass teacher_CLass)
        {
            await _teacherClassService.CreateTeacherClassAsync(teacher_CLass);
            return CreatedAtAction(nameof(GetTeacherClass), new { id = teacher_CLass.Id }, teacher_CLass);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateTeacherClass(int id, Teacher_CLass teacher_CLass)
        {
            if (id != teacher_CLass.Id)
            {
                return BadRequest();
            }

            await _teacherClassService.UpdateTeacherClassAsync(teacher_CLass);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteTeacherClass(int id)
        {
            await _teacherClassService.DeleteTeacherClassAsync(id);
            return NoContent();
        }
    }
}
