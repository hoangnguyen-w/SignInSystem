using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.TuitionType;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff")]
    public class TuitionTypeController : Controller
    {
        private readonly ITuitionTypeService _tuitionTypeService;
        public TuitionTypeController(ITuitionTypeService tuitionTypeService)
        {
            _tuitionTypeService = tuitionTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TuitionType>>> GetAll()
        {
            try
            {
                var list = await _tuitionTypeService.GetAll();

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

        [HttpGet("GetByTuitionTypeID/{id}")]
        public async Task<ActionResult<TuitionType>> GetByID(int id)
        {
            try
            {
                var list = await _tuitionTypeService.GetTuitionTypeID(id);

                if (list == null)
                {
                    return NotFound("TuitionTypeID không tồn tại, vui lòng kiểm tra lại TuitionTypeID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByTuitionTypeName/{name}")]
        public async Task<ActionResult<TuitionType>> GetByName(string name)
        {
            try
            {
                var list = await _tuitionTypeService.GetTuitionTypeName(name);

                if (list == null)
                {
                    return NotFound("Không có kết quả!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateTuitionType(TuitionTypeDTO tuitionTypeDTO)
        {
            try
            {
                await _tuitionTypeService.CreateTuitionType(tuitionTypeDTO);
                return Ok(tuitionTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditTuitionType(int id, TuitionTypeDTO tuitionTypeDTO)
        {
            try
            {
                var list = await _tuitionTypeService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("TuitionTypeID không tồn tại, vui lòng kiểm tra lại TuitionTypeID!!!!");
                }
                await _tuitionTypeService.EditTuitionType(id, tuitionTypeDTO);
                return Ok(tuitionTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteTuitionType(int id)
        {
            try
            {
                var list = await _tuitionTypeService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("TuitionTypeID không tồn tại, vui lòng kiểm tra lại TuitionTypeID!!!!");
                }

                await _tuitionTypeService.DeleteTuitionType(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
