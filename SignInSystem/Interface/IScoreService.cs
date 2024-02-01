using SignInSystem.DTO.Score;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IScoreService
    {
        Task<List<Score>> GetAll();

        Task<List<Score>> DecreasingScore(int subjectID);

        Task<List<Score>> AscendingScore(int subjectID);

        Task<List<Score>> GetScoreTypeByID(int id);

        Task<List<Score>> GetScore(int score);

        Task<List<Score>> GetScoreStudentBySubject(int subjectID, string studentID);

        Task<List<Score>> GetSubjectScoreHight(int id);

        Task<Score> FindIDToResult(int id);

        Task CreateScore(ScoreDTO roleDTO);

        Task EditScore(int scoreTypeID, int subjectID, string studentID, UpdateScoreDTO updateScoreDTO);

        Task DeleteScore(int id);
    }
}
