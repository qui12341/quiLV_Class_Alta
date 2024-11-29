using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Point_CLassService;
using quiLV_ALTA_Class.Services.PointService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;
        public PointController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<IEnumerable<Point>>> GetPoint()
        {
            var point = await _pointService.GetAllPointAsync();
            return Ok(point);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Point>> GetPoint(int id)
        {
            var point = await _pointService.GetPointByIdAsync(id);
            if (point == null)
            {
                return NotFound();
            }
            return Ok(point);
        }

        [HttpPost]
        [Authorize(Roles = "1,2")]

        public async Task<ActionResult<Point>> CreatePoint(Point point)
        {
            await _pointService.CreatePointAsync(point);
            return CreatedAtAction(nameof(GetPoint), new { id = point.Point_ID }, point);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> UpdatePoint(int id, Point point)
        {
            if (id != point.Point_ID)
            {
                return BadRequest();
            }

            await _pointService.UpdatePointAsync(point);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> DeletePointClass(int id)
        {
            await _pointService.DeletePointAsync(id);
            return NoContent();
        }
    }
}
