using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.ScoreType;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class ScoreTypeService : IScoreTypeService
    {
        private readonly SignInSystemContext _context;

        public ScoreTypeService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateScoreType(ScoreTypeDTO scoreTypeDTO)
        {
            ScoreType scoreType = new ScoreType();
            
            scoreType.ScoreTypeName = scoreTypeDTO.ScoreTypeName;
            scoreType.Coefficient = scoreTypeDTO.Coefficient;

            _context.ScoreTypes.Add(scoreType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScoreType(int id)
        {
            var list = _context.ScoreTypes.FirstOrDefault(s => s.ScoreTypeID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditScoreType(int id, ScoreTypeDTO scoreTypeDTO)
        {
            var list = _context.ScoreTypes.FirstOrDefault(s => s.ScoreTypeID == id);

            list.ScoreTypeName = scoreTypeDTO.ScoreTypeName;
            list.Coefficient = scoreTypeDTO.Coefficient;

            _context.ScoreTypes.Update(list);
            await _context.SaveChangesAsync();
        }

        public async Task<ScoreType> FindIDToResult(int id)
        {
            var list = await _context.ScoreTypes.FindAsync(id);
            return list;
        }

        public async Task<List<ScoreType>> GetAll()
        {
            var list = await _context.ScoreTypes.ToListAsync();
            return list;
        }

        public async Task<List<ScoreType>> GetScoreTypeByID(int id)
        {
            var list = await _context.ScoreTypes.Where(s => s.ScoreTypeID == id).ToListAsync();
            return list;
        }

        public async Task<List<ScoreType>> GetScoreTypeByName(string scoreTypeName)
        {
            var list = await _context.ScoreTypes.Where(r => r.ScoreTypeName.Trim().ToLower().Contains(scoreTypeName.Trim().ToLower())).ToListAsync();
            return list;
        }
    }
}
