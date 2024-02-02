using SignInSystem.DTO.Teacher;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetAll();

        Task<List<Teacher>> GetTeacherByID(string id);

        Task<List<Teacher>> GetTeacherByEmail(string email);

        Task<List<Teacher>> GetTeacherByName(string name);

        Task<Teacher> FindIDToResult(string id);

        Task<List<Teacher>> SearchTeacherNameEmailID(string search);

        Task CreateTeacher(RegisterTeacherDTO registerTeacherDTO);

        Task CreateTeacherInClass(string teacherID, string classID);

        Task EditTeacher(string id, UpdateTeacherDTO updateTeacherDTO);

        Task DeleteTeacher(string id);
    }
}
