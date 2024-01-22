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

        Task<Class> FindClassID(string id);

        Task<List<Student>> SearchStudentNameEmailID(string search);

        Task CreateStudent(RegisterStudentDTO registerStudentDTO);

        Task CreateStudenInClass(string id, string classID);

        Task EditStudent(string id, UpdateStudentDTO updateStudentDTO);

        Task DeleteStudentInClass(string id, string classID);

        Task DeleteStudent(string id);
    }
}
