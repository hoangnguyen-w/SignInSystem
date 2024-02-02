using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Holiday;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class HolidayController : Controller
    {
        private readonly IHolidayService _holidayService;
        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Holiday>>> GetAll()
        {
            try
            {
                var list = await _holidayService.GetAll();

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

        [Authorize(Roles = "Admin")]
        [HttpGet("GetByHolidayID/{id}")]
        public async Task<ActionResult<Holiday>> GetByID(int id)
        {
            try
            {
                var list = await _holidayService.GetHolidayByID(id);

                if (list == null)
                {
                    return NotFound("HolidayID không tồn tại, vui lòng kiểm tra lại HolidayID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByHolidayName/{name}")]
        public async Task<ActionResult<Role>> GetByName(string name)
        {
            try
            {
                var list = await _holidayService.GetHolidayByName(name);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<ActionResult> CreateHoliday(HolidayDTO holidayDTO)
        {
            try
            {
                await _holidayService.CreateHoliday(holidayDTO);
                return Ok(holidayDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditHoliday(int id, HolidayDTO holidayDTO)
        {
            try
            {
                var list = await _holidayService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("HolidayID không tồn tại, vui lòng kiểm tra lại HolidayID!!!!");
                }
                await _holidayService.EditHoliday(id, holidayDTO);
                return Ok(holidayDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteHoliday(int id)
        {
            try
            {
                var list = await _holidayService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("HolidayID không tồn tại, vui lòng kiểm tra lại HolidayID!!!!");
                }

                await _holidayService.DeleteHoliday(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
