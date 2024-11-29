using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Point_TypeService
{
    public interface IPointTypeService
    {
        Task<IEnumerable<Point_Type>> GetAllPointTypeAsync();
        Task<Point_Type> GetPointTypeByIdAsync(int id);
        Task CreatePointTypeAsync(Point_Type point_Type);
        Task UpdatePointTypeAsync(Point_Type point_Type);
        Task DeletePointTypeAsync(int id);
    }
}
