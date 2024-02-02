using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Teacher;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly SignInSystemContext _context;

        public TeacherService(SignInSystemContext context)
        {
            _context = context;
        }


        public async Task CreateTeacher(RegisterTeacherDTO registerTeacherDTO)
        {
            Teacher teacher = new Teacher();

            var check = await _context.Subjects.FirstOrDefaultAsync(t => t.SubjectID == registerTeacherDTO.SubjectID);
            if (check == null)
            {
                throw new BadHttpRequestException("SubjectID không tồn tại, vui lòng kiểm tra lại SubjectID!!!!");
            }
            else
            {
                teacher.TeacherName = registerTeacherDTO.TeacherName;
                teacher.Email = registerTeacherDTO.Email;
                teacher.Password = registerTeacherDTO.Password;
                teacher.TaxCode = registerTeacherDTO.TaxCode;
                teacher.Address = registerTeacherDTO.Address;
                teacher.DateOfBirth = registerTeacherDTO.DateOfBirth;
                teacher.Phone = registerTeacherDTO.Phone;
                teacher.Image = registerTeacherDTO.Image;
                teacher.SubjectID = registerTeacherDTO.SubjectID;
                teacher.RoleID = 3;

                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteTeacher(string id)
        {
            var list = _context.Teachers.FirstOrDefault(t => t.TeacherID == id);

            _context.Teachers.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditTeacher(string id, UpdateTeacherDTO updateTeacherDTO)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.TeacherID == id);

            var check = await _context.Subjects.FirstOrDefaultAsync(t => t.SubjectID == updateTeacherDTO.SubjectID);
            if (check == null)
            {
                throw new BadHttpRequestException("SubjectID không tồn tại, vui lòng kiểm tra lại SubjectID!!!!");
            }
            else
            {
                teacher.TeacherName = updateTeacherDTO.TeacherName;
                teacher.Password = updateTeacherDTO.Password;
                teacher.TaxCode = updateTeacherDTO.TaxCode;
                teacher.Address = updateTeacherDTO.Address;
                teacher.DateOfBirth = updateTeacherDTO.DateOfBirth;
                teacher.Phone = updateTeacherDTO.Phone;
                teacher.Image = updateTeacherDTO.Image;
                teacher.SubjectID = updateTeacherDTO.SubjectID;

                _context.Teachers.Update(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Teacher> FindIDToResult(string id)
        {
            var search = await _context.Teachers.FindAsync(id);
            return search;
        }

        public async Task<List<Teacher>> GetAll()
        {
            var list = await _context.Teachers.ToListAsync();
            return list;
        }

        public async Task<List<Teacher>> GetTeacherByEmail(string email)
        {
            var list = await _context.Teachers.Where(a => a.Email.Trim().ToLower().Contains(email.Trim().ToLower())).ToListAsync();
            return list;
        }

        public async Task<List<Teacher>> GetTeacherByID(string id)
        {
            var list = await _context.Teachers.Where(a => a.TeacherID.Equals(id)).ToListAsync();
            return list;
        }

        public async Task<List<Teacher>> GetTeacherByName(string name)
        {
            var list = await _context.Teachers.Where(a => a.TeacherName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;
        }

        public async Task<List<Teacher>> SearchTeacherNameEmailID(string search)
        {
            var list = await _context.Teachers
                .Where(a => a.TeacherName.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                            a.Email.Trim().ToLower().Contains(search.Trim().ToLower()) ||
                            a.TeacherID.Trim().ToLower().Contains(search.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
