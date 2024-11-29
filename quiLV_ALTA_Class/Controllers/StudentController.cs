using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Class;
using quiLV_ALTA_Class.Services.StudentService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            var student = await _studentService.GetAllStudentAsync();
            return Ok(student);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            await _studentService.CreateStudentAsync(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Student_Id }, student);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateClass(int id, Student student)
        {
            if (id != student.Student_Id)
            {
                return BadRequest();
            }

            await _studentService.UpdateStudentAsync(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}
