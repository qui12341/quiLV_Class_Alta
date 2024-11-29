using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Subject_ClassService;
using quiLV_ALTA_Class.Services.TeacherClassService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class SubjectClassController : ControllerBase
    {
        private readonly ISubjectClassService _subjectClassService;
        public SubjectClassController(ISubjectClassService subjectClassService)
        {
            _subjectClassService = subjectClassService;
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<IEnumerable<Subject_Class>>> GetSubjectClass()
        {
            var subject_Classes = await _subjectClassService.GetAllSubjectClassAsync();
            return Ok(subject_Classes);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Subject_Class>> GetSubjectClass(int id)
        {
            var subject_Class = await _subjectClassService.GetSubjectClassByIdAsync(id);
            if (subject_Class == null)
            {
                return NotFound();
            }
            return Ok(subject_Class);
        }

        [HttpPost]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Subject_Class>> CreateSubjectClass(Subject_Class subject_Class)
        {
            await _subjectClassService.CreateSubjectClassAsync(subject_Class);
            return CreatedAtAction(nameof(GetSubjectClass), new { id = subject_Class.Id }, subject_Class);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> UpdateSubjectClass(int id, Subject_Class subject_Class)
        {
            if (id != subject_Class.Id)
            {
                return BadRequest();
            }

            await _subjectClassService.UpdateSubjectClassAsync(subject_Class);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> DeleteTeacherClass(int id)
        {
            await _subjectClassService.DeleteSubjectClassAsync(id);
            return NoContent();
        }
    }
}
