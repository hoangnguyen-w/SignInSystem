using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Score;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff, Teacher")]
    public class ScoreController : Controller
    {
        private readonly IScoreService _scoreService;
        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Score>>> GetAll()
        {
            try
            {
                var list = await _scoreService.GetAll();

                if (list == null)
                {
                    return NotFound("Server lỗi rồi");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("DecreasingScore")]
        public async Task<ActionResult<List<Score>>> DecreasingScore(int subjectID)
        {
            try
            {
                var list = await _scoreService.DecreasingScore(subjectID);

                if (list == null)
                {
                    return NotFound("Server lỗi rồi");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("AscendingScore")]
        public async Task<ActionResult<List<Score>>> AscendingScore(int subjectID)
        {
            try
            {
                var list = await _scoreService.AscendingScore(subjectID);

                if (list == null)
                {
                    return NotFound("Server lỗi rồi");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetScoreTypeByID/{id}")]
        public async Task<ActionResult<Score>> GetScoreTypeByID(int id)
        {
            try
            {
                var list = await _scoreService.GetScoreTypeByID(id);

                if (list == null)
                {
                    return NotFound("ScoreID không tồn tại, vui lòng kiểm tra lại ScoreID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByScore/{score}")]
        public async Task<ActionResult<Score>> GetScore(int score)
        {
            try
            {
                var list = await _scoreService.GetScore(score);

                if (list == null)
                {
                    return NotFound("Score không tồn tại, vui lòng kiểm tra lại Score!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetScoreStudentBySubject/{subjectID}/{studentID}")]
        public async Task<ActionResult<Score>> GetScore(int subjectID, string studentID)
        {
            try
            {
                var list = await _scoreService.GetScoreStudentBySubject(subjectID, studentID);

                if (list == null)
                {
                    return NotFound("Score không tồn tại, vui lòng kiểm tra lại Score!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetSubjectScoreHight/{subjectID}")]
        public async Task<ActionResult<Score>> GetSubjectScoreHight(int subjectID)
        {
            try
            {
                var list = await _scoreService.GetSubjectScoreHight(subjectID);

                if (list == null)
                {
                    return NotFound("Score không tồn tại, vui lòng kiểm tra lại Score!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateScore(ScoreDTO scoreDTO)
        {
            try
            {
                await _scoreService.CreateScore(scoreDTO);
                return Ok(scoreDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{scoreTypeID}/{subjectID}/{studentID}")]
        public async Task<ActionResult> EditScore(int scoreTypeID, int subjectID, string studentID, UpdateScoreDTO updateScoreDTO)
        {
            try
            {
                await _scoreService.EditScore(scoreTypeID, subjectID, studentID, updateScoreDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteScore(int id)
        {
            try
            {
                var list = await _scoreService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ScoreID không tồn tại, vui lòng kiểm tra lại ScoreID!!!!");
                }

                await _scoreService.DeleteScore(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
