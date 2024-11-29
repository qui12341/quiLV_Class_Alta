using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Holiday_ScheduleService
{
    public interface IHoliday_ScheduleService
    {
        Task<IEnumerable<Holiday_schedule>> GetAllHolidayScheduleAsync();
        Task<Holiday_schedule> GetHolidayScheduleByIdAsync(int id);
        Task CreateHolidayScheduleAsync(Holiday_schedule holiday_Schedule);
        Task UpdateHolidayScheduleAsync(Holiday_schedule holiday_Schedule);
        Task DeleteHolidayScheduleAsync(int id);
    }
}
