using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Class;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff")]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Class>>> GetAll()
        {
            try
            {
                var list = await _classService.GetAll();

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

        [HttpGet("GetByClassID/{id}")]
        public async Task<ActionResult<Class>> GetByID(string id)
        {
            try
            {
                var list = await _classService.GetClassByID(id);

                if (list == null)
                {
                    return NotFound("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByClassName/{name}")]
        public async Task<ActionResult<Class>> GetByName(string name)
        {
            try
            {
                var list = await _classService.GetClassByName(name);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateClass(ClassDTO classDTO)
        {
            try
            {
                await _classService.CreateClass(classDTO);
                return Ok(classDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditClass(string id, UpdateClassDTO updateClassDTO)
        {
            try
            {
                var list = await _classService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                }
                await _classService.EditClass(id, updateClassDTO);
                return Ok(updateClassDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ChangStatusClass/{id}")]
        public async Task<ActionResult> ChangStatusClass(string id)
        {
            try
            {
                var list = await _classService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                }
                await _classService.EditStatusClass(id);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteClass(string id)
        {
            try
            {
                var list = await _classService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                }

                await _classService.DeleteClass(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
