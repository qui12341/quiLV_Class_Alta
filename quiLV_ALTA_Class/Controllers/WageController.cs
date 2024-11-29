using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.UserService;
using quiLV_ALTA_Class.Services.WageService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WageController : ControllerBase
    {
        private readonly IWageService _wageService;
        public WageController(IWageService wageService)
        {
            _wageService = wageService;
        }
        [HttpGet]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<IEnumerable<Wage>>> GetWage()
        {
            var users = await _wageService.GetAllWageAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Wage>> GetWage(int id)
        {
            var wage = await _wageService.GetWageByIdAsync(id);
            if (wage == null)
            {
                return NotFound();
            }
            return Ok(wage);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Wage>> CreateWage(Wage wage)
        {
            await _wageService.CreateWageAsync(wage);
            return CreatedAtAction(nameof(GetWage), new { id = wage.Wage_ID }, wage);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateWage(int id, Wage wage)
        {
            if (id != wage.Wage_ID)
            {
                return BadRequest();
            }

            await _wageService.UpdateWageAsync(wage);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteWage(int id)
        {
            await _wageService.DeleteWageAsync(id);
            return NoContent();
        }
    }
}
