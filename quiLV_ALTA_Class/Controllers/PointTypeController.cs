using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Point_CLassService;
using quiLV_ALTA_Class.Services.Point_TypeService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PointTypeController : ControllerBase
    {
        private readonly IPointTypeService _pointTypeService;
        public PointTypeController(IPointTypeService pointTypeService)
        {
            _pointTypeService = pointTypeService;
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<IEnumerable<Point_Type>>> GetPointType()
        {
            var point_Types = await _pointTypeService.GetAllPointTypeAsync();
            return Ok(point_Types);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Point_Type>> GetPointType(int id)
        {
            var point_Type = await _pointTypeService.GetPointTypeByIdAsync(id);
            if (point_Type == null)
            {
                return NotFound();
            }
            return Ok(point_Type);
        }

        [HttpPost]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Point_Type>> CreatePointType(Point_Type point_Type)
        {
            await _pointTypeService.CreatePointTypeAsync(point_Type);
            return CreatedAtAction(nameof(GetPointType), new { id = point_Type.Point_Type_ID }, point_Type);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> UpdatePointType(int id, Point_Type point_Type)
        {
            if (id != point_Type.Point_Type_ID)
            {
                return BadRequest();
            }

            await _pointTypeService.UpdatePointTypeAsync(point_Type);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> DeletePointClass(int id)
        {
            await _pointTypeService.DeletePointTypeAsync(id);
            return NoContent();
        }
    }
}
