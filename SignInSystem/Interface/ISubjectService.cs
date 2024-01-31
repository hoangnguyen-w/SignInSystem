using SignInSystem.DTO.Subject;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAll();

        Task<List<Subject>> GetSubjectByID(int id);

        Task<List<Subject>> GetSubjectByName(string subjectName);

        Task<Subject> FindIDToResult(int id);

        Task CreateSubject(SubjectDTO subjectDTO);

        Task EditSubject(int id, SubjectDTO subjectDTO);

        Task DeleteSubject(int id);
    }
}
