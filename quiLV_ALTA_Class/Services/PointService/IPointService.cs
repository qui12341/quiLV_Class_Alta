using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.PointService
{
    public interface IPointService
    {
        Task<IEnumerable<Point>> GetAllPointAsync();
        Task<Point> GetPointByIdAsync(int id);
        Task CreatePointAsync(Point point);
        Task UpdatePointAsync(Point point);
        Task DeletePointAsync(int id);
    }
}
