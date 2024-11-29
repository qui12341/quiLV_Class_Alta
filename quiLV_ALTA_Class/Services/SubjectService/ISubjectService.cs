using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.SubjectService
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllSubjectAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task CreateSubjectAsync(Subject subject);
        Task UpdateSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(int id);
    }
}
