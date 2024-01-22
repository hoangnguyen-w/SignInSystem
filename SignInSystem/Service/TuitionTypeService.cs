using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.TuitionType;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class TuitionTypeService : ITuitionTypeService
    {
        private readonly SignInSystemContext _context;

        public TuitionTypeService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateTuitionType(TuitionTypeDTO tuitionTypeDTO)
        {
            TuitionType tuitionType = new TuitionType();
            tuitionType.TuitionTypeName = tuitionTypeDTO.TuitionTypeName;   

            _context.TuitionTypes.Add(tuitionType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTuitionType(int id)
        {
            var list = _context.TuitionTypes.FirstOrDefault(r => r.TuitionTypeID == id);

            _context.TuitionTypes.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditTuitionType(int id, TuitionTypeDTO tuitionTypeDTO)
        {
            var list = _context.TuitionTypes.FirstOrDefault(r => r.TuitionTypeID == id);

            list.TuitionTypeName = tuitionTypeDTO.TuitionTypeName;

            _context.TuitionTypes.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task<TuitionType> FindIDToResult(int id)
        {
            var list = await _context.TuitionTypes.FindAsync(id);
            return list;
        }

        public async Task<List<TuitionType>> GetAll()
        {
            var list = await _context.TuitionTypes.ToListAsync();
            return list;
        }

        public async Task<List<TuitionType>> GetTuitionTypeID(int id)
        {
            var list = await _context.TuitionTypes.Where(r => r.TuitionTypeID == id).ToListAsync();
            return list;
        }

        public async Task<List<TuitionType>> GetTuitionTypeName(string tuitionTypeName)
        {
            var list = await _context.TuitionTypes.Where(r => r.TuitionTypeName.Trim().ToLower().Contains(tuitionTypeName.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
