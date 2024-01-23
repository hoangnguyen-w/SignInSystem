using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Semester;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class SemesterService : ISemesterService
    {
        private readonly SignInSystemContext _context;

        public SemesterService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateSemester(SemesterDTO semesterDTO)
        {
            Semester semester = new Semester();
            semester.SemesterName = semesterDTO.SemesterName;

            _context.Semesters.Add(semester);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSemester(int id)
        {
            var list = _context.Semesters.FirstOrDefault(s => s.SemesterID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditSemester(int id, SemesterDTO semesterDTO)
        {
            var list = _context.Semesters.FirstOrDefault(s => s.SemesterID == id);

            list.SemesterName = semesterDTO.SemesterName;

            _context.Semesters.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task<Semester> FindIDToResult(int id)
        {
            var list = await _context.Semesters.FindAsync(id);
            return list;
        }

        public async Task<List<Semester>> GetAll()
        {
            var list = await _context.Semesters.ToListAsync();
            return list;
        }

        public async Task<List<Semester>> GetSemesterByID(int id)
        {
            var list = await _context.Semesters.Where(s => s.SemesterID == id).ToListAsync();
            return list;
        }

        public async Task<List<Semester>> GetSemesterByName(string semesterName)
        {
            var list = await _context.Semesters.Where(s => s.SemesterName.Trim().ToLower().Contains(semesterName.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
