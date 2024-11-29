using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.PointService;
using quiLV_ALTA_Class.Services.SubjectService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<IEnumerable<Subject>>> GetSubject()
        {
            var subjects = await _subjectService.GetAllSubjectAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Subject>> CreatePoint(Subject subject)
        {
            await _subjectService.CreateSubjectAsync(subject);
            return CreatedAtAction(nameof(GetSubject), new { id = subject.Subject_ID }, subject);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateSubject(int id, Subject subject)
        {
            if (id != subject.Subject_ID)
            {
                return BadRequest();
            }

            await _subjectService.UpdateSubjectAsync(subject);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteSubject(int id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return NoContent();
        }
    }
}
