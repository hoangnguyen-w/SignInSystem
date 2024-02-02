using SignInSystem.DTO.Salary;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface ISalaryService
    {
        Task<List<Salary>> GetSalaryByID(int id);

        Task<List<Salary>> GetSalaryTeacherByID(string id);

        Task<Salary> FindIDToResult(int id);

        Task CreateSalary(SalaryDTO salaryDTO);

        Task EditSalary(int id, SalaryDTO salaryDTO);

        Task DeleteSalary(int id,string teacherID);
    }
}
