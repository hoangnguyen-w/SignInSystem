using SignInSystem.DTO.Student;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IStudentService
    {
        Task<List<Student>> GetAll();

        Task<List<Student>> GetAllNewStudent();

        Task<List<Student>> GetStudentByID(int id);

        Task<List<Student>> GetStudentByEmail(string email);

        Task<List<Student>> GetStudentByName(string email);

        Task<Student> FindIDToResult(int id);

        Task CreateAccount(RegisterStudentDTO registerStudentDTO);

        Task EditAccount(int id, UpdateStudentDTO updateStudentDTO);

        Task DeleteAccount(int id);
    }
}
