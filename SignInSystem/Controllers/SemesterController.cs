using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Semester;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff")]
    public class SemesterController : Controller
    {
        private readonly ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Semester>>> GetAll()
        {
            try
            {
                var list = await _semesterService.GetAll();

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

        [HttpGet("GetBySemesterID/{id}")]
        public async Task<ActionResult<Semester>> GetByID(int id)
        {
            try
            {
                var list = await _semesterService.GetSemesterByID(id);

                if (list == null)
                {
                    return NotFound("SemesterID không tồn tại, vui lòng kiểm tra lại SemesterID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetBySemesterName/{name}")]
        public async Task<ActionResult<Semester>> GetByName(string name)
        {
            try
            {
                var list = await _semesterService.GetSemesterByName(name);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateSemester(SemesterDTO semesterDTO)
        {
            try
            {
                await _semesterService.CreateSemester(semesterDTO);
                return Ok(semesterDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditSemester(int id, SemesterDTO semesterDTO)
        {
            try
            {
                var list = await _semesterService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("SemesterID không tồn tại, vui lòng kiểm tra lại SemesterID!!!!");
                }
                await _semesterService.EditSemester(id, semesterDTO);
                return Ok(semesterDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteSemester(int id)
        {
            try
            {
                var list = await _semesterService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("SemesterID không tồn tại, vui lòng kiểm tra lại SemesterID!!!!");
                }

                await _semesterService.DeleteSemester(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
