using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quiLV_ALTA_Class.Model;
using quiLV_ALTA_Class.Services.Class;
using quiLV_ALTA_Class.Services.Holiday_ScheduleService;

namespace quiLV_ALTA_Class.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class HolidayScheduleController : ControllerBase
    {
        private readonly IHoliday_ScheduleService _holidayScheduleService;
        public HolidayScheduleController(IHoliday_ScheduleService holidayScheduleService)
        {
            _holidayScheduleService = holidayScheduleService;
        }
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<IEnumerable<Holiday_schedule>>> GetHolidaySchedule()
        {
            var holiday_Schedules = await _holidayScheduleService.GetAllHolidayScheduleAsync();
            return Ok(holiday_Schedules);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1,2")]
        public async Task<ActionResult<Holiday_schedule>> GetHolidaySchedule(int id)
        {
            var holiday_Schedule = await _holidayScheduleService.GetHolidayScheduleByIdAsync(id);
            if (holiday_Schedule == null)
            {
                return NotFound();
            }
            return Ok(holiday_Schedule);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<Holiday_schedule>> Create(Holiday_schedule holiday_Schedule)
        {
            await _holidayScheduleService.CreateHolidayScheduleAsync(holiday_Schedule);
            return CreatedAtAction(nameof(GetHolidaySchedule), new { id = holiday_Schedule.Holiday_Schedule_Id }, holiday_Schedule);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> UpdateHolidaySchedule(int id, Holiday_schedule holiday_Schedule)
        {
            if (id != holiday_Schedule.Holiday_Schedule_Id)
            {
                return BadRequest();
            }

            await _holidayScheduleService.UpdateHolidayScheduleAsync(holiday_Schedule);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> DeleteHolidaySchedule(int id)
        {
            await _holidayScheduleService.DeleteHolidayScheduleAsync(id);
            return NoContent();
        }
    }
}
