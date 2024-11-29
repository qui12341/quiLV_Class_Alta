using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.CalendarService;
using quiLV_ALTA_Class.Services.Class;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<IEnumerable<Calendar>>> GetCalendar()
        {
            var calendars = await _calendarService.GetAllCalendarAsync();
            return Ok(calendars);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Calendar>> GetCalendar(int id)
        {
            var calendar = await _calendarService.GetCalendarByIdAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }
            return Ok(calendar);
        }

        [HttpPost]
        [Authorize(Roles = "1")]

        public async Task<ActionResult<Calendar>> CreateCalendar(Calendar calendar)
        {
            await _calendarService.CreateCalendarAsync(calendar);
            return CreatedAtAction(nameof(GetCalendar), new { id = calendar.Id }, calendar);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> UpdateCalendar(int id, Calendar calendar)
        {
            if (id != calendar.Id)
            {
                return BadRequest();
            }

            await _calendarService.UpdateCalendarClassAsync(calendar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteCalendar(int id)
        {
            await _calendarService.DeleteCalendarAsync(id);
            return NoContent();
        }
    }
}
