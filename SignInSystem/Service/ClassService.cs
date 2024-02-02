using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Class;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class ClassService : IClassService
    {
        private readonly SignInSystemContext _context;

        public ClassService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateClass(ClassDTO classDTO)
        {
            Class cla = new Class();
            cla.ClassID = classDTO.ClassID;
            cla.ClassName = classDTO.ClassName;
            cla.Discription = classDTO.Discription;
            cla.Price = classDTO.Price;
            cla.SlotStudent = classDTO.SlotStudent;
            cla.StatusClass = 1;
            cla.SemesterID = classDTO.SemesterID;
            cla.SubjectID = classDTO.SubjectID;


            _context.Classes.Add(cla);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClass(string id)
        {
            var list = _context.Classes.FirstOrDefault(c => c.ClassID.Equals(id));

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditClass(string id, UpdateClassDTO classDTO)
        {
            var cla = _context.Classes.FirstOrDefault(c => c.ClassID.Equals(id));

            cla.ClassName = classDTO.ClassName;
            cla.Discription = classDTO.Discription;
            cla.Price = classDTO.Price;
            cla.SlotStudent = classDTO.SlotStudent;
            cla.StatusClass = 1;
            cla.SemesterID = classDTO.SemesterID;
            cla.SubjectID = classDTO.SubjectID;

            _context.Classes.Update(cla);
            await _context.SaveChangesAsync();
        }

        public async Task EditStatusClass(string id)
        {
            var cla = _context.Classes.FirstOrDefault(c => c.ClassID.Equals(id));
            
            if(cla.StatusClass == 2)
            {
                cla.StatusClass = 1;
                _context.Classes.Update(cla);
                await _context.SaveChangesAsync();
            }
            else if(cla.StatusClass == 1)
            {
                cla.StatusClass = 2;
                _context.Classes.Update(cla);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Class> FindIDToResult(string id)
        {
            var list = await _context.Classes.FindAsync(id);
            return list;
        }

        public async Task<List<Class>> GetAll()
        {
            var list = await _context.Classes.ToListAsync();
            return list;
        }

        public async Task<List<Class>> GetClassByID(string id)
        {
            var list = await _context.Classes.Where(c => c.ClassID.Equals(id)).ToListAsync();
            return list;
        }

        public async Task<List<Class>> GetClassByName(string className)
        {
            var list = await _context.Classes.Where(r => r.ClassName.Trim().ToLower().Contains(className.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
