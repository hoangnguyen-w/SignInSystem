using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Voucher;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff")]
    public class VoucherController : Controller
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Voucher>>> GetAll()
        {
            try
            {
                var list = await _voucherService.GetAll();

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

        [HttpGet("GetByVoucherID/{id}")]
        public async Task<ActionResult<Voucher>> GetByID(int id)
        {
            try
            {
                var list = await _voucherService.GetVoucherByID(id);

                if (list == null)
                {
                    return NotFound("VoucherID không tồn tại, vui lòng kiểm tra lại VoucherID!!!!");
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByVoucherName/{name}")]
        public async Task<ActionResult<Voucher>> GetByName(string name)
        {
            try
            {
                var list = await _voucherService.GetVoucherByName(name);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateVoucher(VoucherDTO voucherDTO)
        {
            try
            {
                await _voucherService.CreateVoucher(voucherDTO);
                return Ok(voucherDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditVoucher(int id, VoucherDTO voucherDTO)
        {
            try
            {
                var list = await _voucherService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("VoucherID không tồn tại, vui lòng kiểm tra lại VoucherID!!!!");
                }
                await _voucherService.EditVoucher(id, voucherDTO);
                return Ok(voucherDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ChangStatusVoucher/{id}")]
        public async Task<ActionResult> ChangStatusVoucher(int id)
        {
            try
            {
                var list = await _voucherService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("VoucherID không tồn tại, vui lòng kiểm tra lại VoucherID!!!!");
                }
                await _voucherService.ChangeStatusVoucher(id);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteVoucher(int id)
        {
            try
            {
                var list = await _voucherService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("RoleID không tồn tại, vui lòng kiểm tra lại RoleID!!!!");
                }

                await _voucherService.DeleteVoucher(id);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
