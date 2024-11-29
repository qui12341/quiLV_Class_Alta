using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.RevenueService
{
    public interface IRevenueService
    {
        Task<IEnumerable<Revenue>> GetAllRevenueAsync();
        Task<Revenue> GetRevenueByIdAsync(int id);
        Task CreateRevenueAsync(Revenue revenues);
        Task UpdateRevenueAsync(Revenue revenues);
        Task DeleteRevenueAsync(int id);
    }
}
