using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.RoleService;
using quiLV_ALTA_Class.Services.Student_ClassService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassService _studentClassService;
        public StudentClassController(IStudentClassService studentClassService)
        {
            _studentClassService = studentClassService;
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<IEnumerable<Student_Class>>> GetStudentClass()
        {
            var student_Classes = await _studentClassService.GetAllStudentClassAsync();
            return Ok(student_Classes);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Student_Class>> GetStudentClass(int id)
        {
            var student_Class = await _studentClassService.GetStudentClassByIdAsync(id);
            if (student_Class == null)
            {
                return NotFound();
            }
            return Ok(student_Class);
        }

        [HttpPost]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Student_Class>> CreateStudentClass(Student_Class student_Class)
        {
            await _studentClassService.CreateStudentClassAsync(student_Class);
            return CreatedAtAction(nameof(GetStudentClass), new { id = student_Class.Id }, student_Class);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> UpdateStudentClass(int id, Student_Class student_Class)
        {
            if (id != student_Class.Id)
            {
                return BadRequest();
            }

            await _studentClassService.UpdateStudentClassAsync(student_Class);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> DeleteTeacherClass(int id)
        {
            await _studentClassService.DeleteStudentClassAsync(id);
            return NoContent();
        }
    }
}
