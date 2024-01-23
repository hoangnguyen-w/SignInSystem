using SignInSystem.DTO.Semester;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface ISemesterService
    {
        Task<List<Semester>> GetAll();

        Task<List<Semester>> GetSemesterByID(int id);

        Task<List<Semester>> GetSemesterByName(string semesterName);

        Task<Semester> FindIDToResult(int id);

        Task CreateSemester(SemesterDTO semesterDTO);

        Task EditSemester(int id, SemesterDTO semesterDTO);

        Task DeleteSemester(int id);
    }
}
