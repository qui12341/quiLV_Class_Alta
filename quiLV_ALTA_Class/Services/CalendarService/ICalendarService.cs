using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.CalendarService
{
    public interface ICalendarService
    {
        Task<IEnumerable<Calendar>> GetAllCalendarAsync();
        Task<Calendar> GetCalendarByIdAsync(int id);
        Task CreateCalendarAsync(Calendar calendar);
        Task UpdateCalendarClassAsync(Calendar calendar);
        Task DeleteCalendarAsync(int id);
    }
}
