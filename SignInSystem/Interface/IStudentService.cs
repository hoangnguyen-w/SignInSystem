using SignInSystem.DTO.Student;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();

        Task<List<Student>> GetAllNewStudent();

        Task<List<Student>> GetStudentByID(string id);

        Task<List<Student>> GetStudentByEmail(string email);

        Task<List<Student>> GetStudentByName(string name);

        Task<Student> FindIDToResult(string id);

        Task<List<Student>> SearchStudentNameEmailID(string search);

        Task CreateStudent(RegisterStudentDTO registerStudentDTO);

        Task EditStudent(string id, UpdateStudentDTO updateStudentDTO);

        Task DeleteStudent(string id);
    }
}
