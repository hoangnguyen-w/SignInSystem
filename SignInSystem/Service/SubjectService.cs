using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Subject;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class SubjectService : ISubjectService
    {
        private readonly SignInSystemContext _context;

        public SubjectService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateSubject(SubjectDTO subjectDTO)
        {
            Subject subject = new Subject();
            subject.SubjectName = subjectDTO.SubjectName;
            subject.Time = subjectDTO.Time;

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubject(int id)
        {
            var list = _context.Subjects.FirstOrDefault(s => s.SubjectID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditSubject(int id, SubjectDTO subjectDTO)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.SubjectID == id);

            subject.SubjectName = subjectDTO.SubjectName;
            subject.Time = subjectDTO.Time;

            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }

        public async Task<Subject> FindIDToResult(int id)
        {
            var list = await _context.Subjects.FindAsync(id);
            return list;
        }

        public async Task<List<Subject>> GetAll()
        {
            var list = await _context.Subjects.ToListAsync();
            return list;
        }

        public async Task<List<Subject>> GetSubjectByID(int id)
        {
            var list = await _context.Subjects.Where(s => s.SubjectID == id).ToListAsync();
            return list;
        }

        public async Task<List<Subject>> GetSubjectByName(string subjectName)
        {
            var list = await _context.Subjects.Where(s => s.SubjectName.Trim().ToLower().Contains(subjectName.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
