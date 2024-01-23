using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.ScoreType;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff")]
    public class ScoreTypeController : Controller
    {
        private readonly IScoreTypeService _scoreTypeService;
        public ScoreTypeController(IScoreTypeService scoreTypeService)
        {
            _scoreTypeService = scoreTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ScoreType>>> GetAll()
        {
            try
            {
                var list = await _scoreTypeService.GetAll();

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

        [HttpGet("GetByScoreTypeID/{id}")]
        public async Task<ActionResult<ScoreType>> GetByID(int id)
        {
            try
            {
                var list = await _scoreTypeService.GetScoreTypeByID(id);

                if (list == null)
                {
                    return NotFound("ScoreTypeID không tồn tại, vui lòng kiểm tra lại ScoreTypeID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByScoreTypeName/{name}")]
        public async Task<ActionResult<ScoreType>> GetByName(string name)
        {
            try
            {
                var list = await _scoreTypeService.GetScoreTypeByName(name);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateScoreType(ScoreTypeDTO scoreTypeDTO)
        {
            try
            {
                await _scoreTypeService.CreateScoreType(scoreTypeDTO);
                return Ok(scoreTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditScoreType(int id, ScoreTypeDTO scoreTypeDTO)
        {
            try
            {
                var list = await _scoreTypeService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ScoreTypeID không tồn tại, vui lòng kiểm tra lại ScoreTypeID!!!!");
                }
                await _scoreTypeService.EditScoreType(id, scoreTypeDTO);
                return Ok(scoreTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteScoreType(int id)
        {
            try
            {
                var list = await _scoreTypeService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ScoreTypeID không tồn tại, vui lòng kiểm tra lại ScoreTypeID!!!!");
                }

                await _scoreTypeService.DeleteScoreType(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
