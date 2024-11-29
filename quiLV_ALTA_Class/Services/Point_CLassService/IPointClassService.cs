using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Point_CLassService
{
    public interface IPointClassService
    {
        Task<IEnumerable<Point_Class>> GetAllPointClassAsync();
        Task<Point_Class> GetPointClassByIdAsync(int id);
        Task CreatePointClassAsync(Point_Class point_Class);
        Task UpdatePointClassAsync(Point_Class point_Class);
        Task DeletePointClassAsync(int id);
    }
}
