using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Tuition;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff")]
    public class TuitionController : Controller
    {
        private readonly ITuitionService _tuitionService;
        public TuitionController(ITuitionService tuitionService)
        {
            _tuitionService = tuitionService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Tuition>>> GetAll()
        {
            try
            {
                var list = await _tuitionService.GetAll();

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

        [HttpGet("GetPayTution")]
        public async Task<ActionResult<List<Tuition>>> GetPayTution()
        {
            try
            {
                var list = await _tuitionService.GetPayTution();

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

        [HttpGet("GetByTuitionID/{id}")]
        public async Task<ActionResult<Tuition>> GetByID(int id)
        {
            try
            {
                var list = await _tuitionService.GetTuitionByID(id);

                if (list == null)
                {
                    return NotFound("TuitionID không tồn tại, vui lòng kiểm tra lại TuitionID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateTuition(TuitionDTO tuitionDTO)
        {
            try
            {
                await _tuitionService.CreateTuition(tuitionDTO);
                return Ok(tuitionDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditTuition(int id, UpdateTuitionDTO updateTuitionDTO)
        {
            try
            {
                var list = await _tuitionService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("TuitionID không tồn tại, vui lòng kiểm tra lại TuitionID!!!!");
                }
                await _tuitionService.EditTuition(id, updateTuitionDTO);
                return Ok(updateTuitionDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ChangStautsTuition/{id}")]
        public async Task<ActionResult> ChangStautsTuition(int id)
        {
            try
            {
                var list = await _tuitionService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("TuitionID không tồn tại, vui lòng kiểm tra lại TuitionID!!!!");
                }
                await _tuitionService.ChangStautsTuition(id);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("AddVoucherTuition/{id}")]
        public async Task<ActionResult> AddVoucherTuition(int id, AddVoucherDTO addVoucherDTO)
        {
            try
            {
                var list = await _tuitionService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("TuitionID không tồn tại, vui lòng kiểm tra lại TuitionID!!!!");
                }
                await _tuitionService.AddVoucherTuition(id, addVoucherDTO);
                return Ok("VoucherID: " + addVoucherDTO.VoucherID + " - Voucher: " + list.Student.Voucher.VoucherName + " sử dụng thành công");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteTuition(int id)
        {
            try
            {
                var list = await _tuitionService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("TuitionID không tồn tại, vui lòng kiểm tra lại TuitionID!!!!");
                }

                await _tuitionService.DeleteTuition(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
