using quiLV_ALTA_Class.Model;

namespace quiLV_ALTA_Class.Services.Subject_ClassService
{
    public interface ISubjectClassService
    {
        Task<IEnumerable<Subject_Class>> GetAllSubjectClassAsync();
        Task<Subject_Class> GetSubjectClassByIdAsync(int id);
        Task CreateSubjectClassAsync(Subject_Class subject_Class);
        Task UpdateSubjectClassAsync(Subject_Class subject_Class);
        Task DeleteSubjectClassAsync(int id);
    }
}
