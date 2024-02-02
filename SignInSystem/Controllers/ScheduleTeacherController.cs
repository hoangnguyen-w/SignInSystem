using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.ScheduleTeacher;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleTeacherController : Controller
    {
        private readonly IScheduleTeacherService _scheduleTeacherService;
        public ScheduleTeacherController(IScheduleTeacherService scheduleTeacherService)
        {
            _scheduleTeacherService = scheduleTeacherService;
        }

        [Authorize(Roles = "Admin, Staff, Teacher")]
        [HttpGet("GetRoom/{room}")]
        public async Task<ActionResult<List<ScheduleTeacher>>> GetRoom(string room)
        {
            try
            {
                var list = await _scheduleTeacherService.GetRoom(room);

                if (list == null)
                {
                    return NotFound("Room không tồn tại, vui lòng xem lại Room");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff, Teacher")]
        [HttpGet("GetTeacher/{teacher}")]
        public async Task<ActionResult<List<ScheduleTeacher>>> GetTeacher(string teacherID)
        {
            try
            {
                var list = await _scheduleTeacherService.GetTeacherID(teacherID);

                if (list == null)
                {
                    return NotFound("TeacherID không tồn tại, vui lòng xem lại TeacherID");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet("GetByTeacherID/{id}")]
        public async Task<ActionResult<ScheduleTeacher>> GetByID(int id)
        {
            try
            {
                var list = await _scheduleTeacherService.GetScheduleTeacherByID(id);

                if (list == null)
                {
                    return NotFound("ScheduleTeacherID không tồn tại, vui lòng kiểm tra lại ScheduleTeacherID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPost("Create")]
        public async Task<ActionResult> CreateScheduleStudent(ScheduleTeacherDTO scheduleTeacherDTO)
        {
            try
            {
                await _scheduleTeacherService.CreateScheduleTeacher(scheduleTeacherDTO);
                return Ok(scheduleTeacherDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPut("Update/{id}/{teacherID}")]
        public async Task<ActionResult> EditScheduleStudent(int id, string teacherID, UpdateScheduleTeacherDTO updateScheduleTeacherDTO)
        {
            try
            {
                var list = await _scheduleTeacherService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ScheduleTeacherID không tồn tại, vui lòng kiểm tra lại ScheduleTeacherID!!!!");
                }
                await _scheduleTeacherService.EditScheduleTeacher(id, teacherID, updateScheduleTeacherDTO);
                return Ok(updateScheduleTeacherDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                var list = await _scheduleTeacherService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ScheduleTeacherID không tồn tại, vui lòng kiểm tra lại ScheduleTeacherID!!!!");
                }

                await _scheduleTeacherService.DeleteScheduleTeacher(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
