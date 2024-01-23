using SignInSystem.DTO.ScoreType;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IScoreTypeService
    {
        Task<List<ScoreType>> GetAll();

        Task<List<ScoreType>> GetScoreTypeByID(int id);

        Task<List<ScoreType>> GetScoreTypeByName(string scoreTypeName);

        Task<ScoreType> FindIDToResult(int id);

        Task CreateScoreType(ScoreTypeDTO scoreTypeDTO);

        Task EditScoreType(int id, ScoreTypeDTO scoreTypeDTO);

        Task DeleteScoreType(int id);
    }
}
