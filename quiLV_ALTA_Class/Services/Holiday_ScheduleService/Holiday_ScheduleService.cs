using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Holiday_ScheduleService
{
    public class Holiday_ScheduleService : IHoliday_ScheduleService
    {
        private readonly AppDBContext _context;

        public Holiday_ScheduleService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateHolidayScheduleAsync(Holiday_schedule holiday_Schedule)
        {
            _context.holiday_Schedules.Update(holiday_Schedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHolidayScheduleAsync(int id)
        {
            var holiday_Schedule = await _context.holiday_Schedules.FindAsync(id);
            if (holiday_Schedule != null)
            {
                _context.holiday_Schedules.Remove(holiday_Schedule);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Holiday_schedule>> GetAllHolidayScheduleAsync()
        {
            return await _context.holiday_Schedules.ToListAsync();
        }

        public async Task<Holiday_schedule> GetHolidayScheduleByIdAsync(int id)
        {
            return await _context.holiday_Schedules.FindAsync(id);
        }

        public async Task UpdateHolidayScheduleAsync(Holiday_schedule holiday_Schedule)
        {
            _context.holiday_Schedules.Update(holiday_Schedule);
            await _context.SaveChangesAsync();
        }
    }
}
