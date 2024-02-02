using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Salary;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class SalaryService : ISalaryService
    {
        private readonly SignInSystemContext _context;

        public SalaryService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateSalary(SalaryDTO salaryDTO)
        {
            Salary salary = new Salary();

            var check = await _context.Teachers.FirstOrDefaultAsync(s => s.TeacherID == salaryDTO.TeacherID);

            if (check == null)
            {
                throw new BadHttpRequestException("TeacherID không tồn tại, vui lòng kiểm tra lại TeacherID!!!!");
            }
            else
            {
                var total = await _context.Classes.FirstOrDefaultAsync(s => s.ClassID == check.ClassID);

                if (total == null)
                {
                    throw new BadHttpRequestException("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                }
                else
                {
                    salary.TotalClassRevenue = total.SlotStudent * total.Price;
                    salary.LecturerSalaryPercentStudent = salaryDTO.LecturerSalaryPercentStudent;
                    salary.SalaryAllowance = salaryDTO.SalaryAllowance;
                    salary.Note = salaryDTO.Note;
                    salary.TeacherID = salaryDTO.TeacherID;
                    salary.TotalSalary = (salary.TotalClassRevenue * salaryDTO.LecturerSalaryPercentStudent / 100) + salaryDTO.SalaryAllowance;

                    _context.Salaries.Add(salary);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteSalary(int id, string teacherID)
        {
            var list = _context.Salaries.FirstOrDefaultAsync(s => s.TeacherID == teacherID && s.SalaryID == id);
            if (list == null)
            {
                throw new BadHttpRequestException("TeacherID hoặc SalaryID không tồn tại, vui lòng kiểm tra lại TeacherID và SalaryID!!!!");
            }

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditSalary(int id, SalaryDTO salaryDTO)
        {
            var salary = _context.Salaries.FirstOrDefault(c => c.SalaryID == id);

            if (salary == null)
            {
                throw new BadHttpRequestException("SalaryID không tồn tại, vui lòng kiểm tra lại SalaryID!!!!");
            }
            else
            {
                var check = await _context.Teachers.FirstOrDefaultAsync(s => s.TeacherID == salaryDTO.TeacherID);

                if (check == null)
                {
                    throw new BadHttpRequestException("TeacherID không tồn tại, vui lòng kiểm tra lại TeacherID!!!!");
                }
                else
                {
                    var total = await _context.Classes.FirstOrDefaultAsync(s => s.ClassID == check.ClassID);

                    if (total == null)
                    {
                        throw new BadHttpRequestException("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                    }
                    else
                    {
                        salary.TotalClassRevenue = total.SlotStudent * total.Price;
                        salary.LecturerSalaryPercentStudent = salaryDTO.LecturerSalaryPercentStudent;
                        salary.SalaryAllowance = salaryDTO.SalaryAllowance;
                        salary.Note = salaryDTO.Note;
                        salary.TeacherID = salaryDTO.TeacherID;
                        salary.TotalSalary = (salary.TotalClassRevenue * salaryDTO.LecturerSalaryPercentStudent / 100) + salaryDTO.SalaryAllowance;

                        _context.Salaries.Update(salary);
                        await _context.SaveChangesAsync();
                    }
                }
            }

        }

        public async Task<Salary> FindIDToResult(int id)
        {
            var list = await _context.Salaries.FindAsync(id);
            return list;
        }

        public async Task<List<Salary>> GetSalaryByID(int id)
        {
            var list = await _context.Salaries.Where(s => s.SalaryID == id).ToListAsync();
            return list;
        }

        public async Task<List<Salary>> GetSalaryTeacherByID(string id)
        {
            var list = await _context.Salaries.Where(s => s.TeacherID == id).ToListAsync();
            return list;
        }
    }
}
