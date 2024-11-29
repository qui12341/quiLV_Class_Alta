using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Class;
using quiLV_ALTA_Class.Services.RoleService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<IEnumerable<Classes>>> GetClass()
        {
            var classes = await _classService.GetAllClassAsync();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Classes>> GetClass(int id)
        {
            var classes = await _classService.GetClassByIdAsync(id);
            if (classes == null)
            {
                return NotFound();
            }
            return Ok(classes);
        }

        [HttpPost]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Classes>> CreateClass(Classes classes)
        {
            await _classService.CreateClassAsync(classes);
            return CreatedAtAction(nameof(GetClass), new { id = classes.Class_Id }, classes);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> UpdateClass(int id, Classes classes)
        {
            if (id != classes.Class_Id)
            {
                return BadRequest();
            }

            await _classService.UpdateClassAsync(classes);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> DeleteClass(int id)
        {
            await _classService.DeleteClassAsync(id);
            return NoContent();
        }
    }
}
