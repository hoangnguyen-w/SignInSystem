using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Score;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Service
{
    public class ScoreService : IScoreService
    {

        private readonly SignInSystemContext _context;

        public ScoreService(SignInSystemContext context)
        {
            _context = context;
        }

        public async Task CreateScore(ScoreDTO scoreDTO)
        {
            Score score = new Score();
            score.ScoreMark = scoreDTO.ScoreMark;
            score.StudentID = scoreDTO.StudentID;
            score.ScoreTypeID = scoreDTO.ScoreTypeID;
            score.SubjectID = scoreDTO.SubjectID;


            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScore(int id)
        {
            var list = _context.Scores.FirstOrDefault(s => s.ScoreID == id);

            _context.Remove(list);
            await _context.SaveChangesAsync();
        }

        public async Task EditScore(int scoreTypeID, int subjectID, string studentID, UpdateScoreDTO roleDTO)
        {
            var list = _context.Scores.FirstOrDefault(s => s.SubjectID == subjectID && s.ScoreTypeID == scoreTypeID && s.StudentID == studentID);

            if(list == null)
            {
                throw new BadHttpRequestException("Vui lòng kiểm tra lại subjectID, scoreTypeID, studentID!!!!");
            }
            else
            {
                list.ScoreMark = roleDTO.ScoreMark;

                _context.Scores.Update(list);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Score> FindIDToResult(int id)
        {
            var list = await _context.Scores.FindAsync(id);
            return list;
        }

        public async Task<List<Score>> GetAll()
        {
            var list = await _context.Scores.ToListAsync();
            return list;
        }

        public async Task<List<Score>> AscendingScore(int subjectID)
        {
            var list = await _context.Scores.OrderBy(s => s.ScoreMark).Where(s => s.SubjectID == subjectID).ToListAsync();
            return list;
        }

        public async Task<List<Score>> DecreasingScore(int subjectID)
        {
            var list = await _context.Scores.OrderByDescending(s => s.ScoreMark).Where(s => s.SubjectID == subjectID).ToListAsync();
            return list;
        }

        public async Task<List<Score>> GetScoreTypeByID(int id)
        {
            var list = await _context.Scores.Where(s => s.ScoreTypeID == id).ToListAsync();
            return list;
        }

        public async Task<List<Score>> GetScoreStudentBySubject(int subjectID, string studentID)
        {
            var list = await _context.Scores.Where(s => s.SubjectID == subjectID && s.StudentID == studentID).ToListAsync();
            return list;
        }

        public async Task<List<Score>> GetScore(int score)
        {
            if(score < 10 || score > 0)
            {
                var list = await _context.Scores.Where(s => s.ScoreMark == score).ToListAsync();
                return list;
            }
            else
            {
                throw new BadHttpRequestException("Điểm phải từ 0 đến 10!!!!");
            }
        }

        public async Task<List<Score>> GetSubjectScoreHight(int subjectID)
        {
            var list = await _context.Scores.OrderByDescending(s => s.ScoreMark).Where(s => s.SubjectID == subjectID).ToListAsync();

            var HightScore = list.FirstOrDefault();

            if(HightScore != null)
            {
                var listHightScore = list.Where(s => s.ScoreMark == HightScore.ScoreMark).ToList();
                return listHightScore;
            }
            else
            {
                throw new BadHttpRequestException("Hiện tại không có điểm để lọc");
            }
        }
    }
}
