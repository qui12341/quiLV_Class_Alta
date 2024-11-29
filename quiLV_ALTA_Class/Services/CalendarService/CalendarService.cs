using Microsoft.EntityFrameworkCore;
using quiLV_ALTA_Class.Data;
using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.CalendarService
{
    public class CalendarService : ICalendarService
    {
        private readonly AppDBContext _context;

        public CalendarService(AppDBContext context)
        {
            _context = context;
        }
        public async Task CreateCalendarAsync(Calendar calendar)
        {
            await _context.calendars.AddAsync(calendar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCalendarAsync(int id)
        {
            var calendar = await _context.calendars.FindAsync(id);
            if (calendar != null)
            {
                _context.calendars.Remove(calendar);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Calendar>> GetAllCalendarAsync()
        {
            return await _context.calendars.ToListAsync();
        }

        public async Task<Calendar> GetCalendarByIdAsync(int id)
        {
            return await _context.calendars.FindAsync(id);
        }

        public async Task UpdateCalendarClassAsync(Calendar calendar)
        {
            _context.calendars.Update(calendar);
            await _context.SaveChangesAsync();
        }
    }
}
