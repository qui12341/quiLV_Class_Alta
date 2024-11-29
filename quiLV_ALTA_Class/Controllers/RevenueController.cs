using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Class;
using quiLV_ALTA_Class.Services.RevenueService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;
        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }
        [HttpGet]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<IEnumerable<Revenue>>> GetRevenue()
        {
            var revenues = await _revenueService.GetAllRevenueAsync();
            return Ok(revenues);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Revenue>> GetRevenue(int id)
        {
            var revenues = await _revenueService.GetRevenueByIdAsync(id);
            if (revenues == null)
            {
                return NotFound();
            }
            return Ok(revenues);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Revenue>> CreateRevenue(Revenue revenues)
        {
            await _revenueService.CreateRevenueAsync(revenues);
            return CreatedAtAction(nameof(GetRevenue), new { id = revenues.Revenue_Id }, revenues);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateRevenue(int id, Revenue revenues)
        {
            if (id != revenues.Revenue_Id)
            {
                return BadRequest();
            }

            await _revenueService.UpdateRevenueAsync(revenues);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteRevenue(int id)
        {
            await _revenueService.DeleteRevenueAsync(id);
            return NoContent();
        }
    }
}
