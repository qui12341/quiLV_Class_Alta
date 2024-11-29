using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.WageService
{
    public interface IWageService
    {
        Task<IEnumerable<Wage>> GetAllWageAsync();
        Task<Wage> GetWageByIdAsync(int id);
        Task CreateWageAsync(Wage wage);
        Task UpdateWageAsync(Wage wage);
        Task DeleteWageAsync(int id);
    }
}
