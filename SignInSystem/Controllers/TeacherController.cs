using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Teacher;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff, Teacher")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Teacher>>> GetAll()
        {
            try
            {
                var list = await _teacherService.GetAll();

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

        [HttpGet("GetByTeacherID/{id}")]
        public async Task<ActionResult<Teacher>> GetByID(string id)
        {
            try
            {
                var list = await _teacherService.GetTeacherByID(id);

                if (list == null)
                {
                    return NotFound("TeacherID không tồn tại, vui lòng kiểm tra lại TeacherID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByTeacherName/{name}")]
        public async Task<ActionResult<Teacher>> GetByName(string name)
        {
            try
            {
                var list = await _teacherService.GetTeacherByName(name);    
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByTeacherName/{email}")]
        public async Task<ActionResult<Teacher>> GetByEmail(string email)
        {
            try
            {
                var list = await _teacherService.GetTeacherByEmail(email);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("SearchTeacherNameEmailID/{searcch}")]
        public async Task<ActionResult<Teacher>> SearchTeacherNameEmailID(string searcch)
        {
            try
            {
                var list = await _teacherService.SearchTeacherNameEmailID(searcch);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateTeacher(RegisterTeacherDTO registerTeacherDTO)
        {
            try
            {
                await _teacherService.CreateTeacher(registerTeacherDTO);
                return Ok(registerTeacherDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateTeacher(string id, UpdateTeacherDTO updateTeacherDTO)
        {
            try
            {
                var list = await _teacherService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("RoleID không tồn tại, vui lòng kiểm tra lại RoleID!!!!");
                }
                await _teacherService.EditTeacher(id, updateTeacherDTO);
                return Ok(updateTeacherDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteTeacher(string id)
        {
            try
            {
                var list = await _teacherService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("RoleID không tồn tại, vui lòng kiểm tra lại RoleID!!!!");
                }

                await _teacherService.DeleteTeacher(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
