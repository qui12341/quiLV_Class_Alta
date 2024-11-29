using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Point_CLassService;
using quiLV_ALTA_Class.Services.RoleService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PointClassController : ControllerBase
    {
        private readonly IPointClassService _pointCLassService;
        public PointClassController(IPointClassService pointClassService)
        {
            _pointCLassService = pointClassService;
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<IEnumerable<Point_Class>>> GetPointClass()
        {
            var point_Classes = await _pointCLassService.GetAllPointClassAsync();
            return Ok(point_Classes);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Point_Class>> GetPointClass(int id)
        {
            var point_Class = await _pointCLassService.GetPointClassByIdAsync(id);
            if (point_Class == null)
            {
                return NotFound();
            }
            return Ok(point_Class);
        }

        [HttpPost]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Point_Class>> CreatePointClass(Point_Class point_Class)
        {
            await _pointCLassService.CreatePointClassAsync(point_Class);
            return CreatedAtAction(nameof(GetPointClass), new { id = point_Class.Id }, point_Class);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> UpdatePointClass(int id, Point_Class point_Class)
        {
            if (id != point_Class.Id)
            {
                return BadRequest();
            }

            await _pointCLassService.UpdatePointClassAsync(point_Class);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> DeletePointClass(int id)
        {
            await _pointCLassService.DeletePointClassAsync(id);
            return NoContent();
        }
    }
}
