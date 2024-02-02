using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.ScheduleStudent;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScheduleStudentController : Controller
    {
        private readonly IScheduleStudentService _scheduleStudentService;
        public ScheduleStudentController(IScheduleStudentService scheduleStudentService)
        {
            _scheduleStudentService = scheduleStudentService;
        }

        [Authorize(Roles = "Admin, Staff, Student")]
        [HttpGet("GetRoom/{room}")]
        public async Task<ActionResult<List<ScheduleStudent>>> GetRoom(string room)
        {
            try
            {
                var list = await _scheduleStudentService.GetRoom(room);

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

        [Authorize(Roles = "Admin, Staff, Student")]
        [HttpGet("GetStudent/{student}")]
        public async Task<ActionResult<List<ScheduleStudent>>> GetStudent(string studentID)
        {
            try
            {
                var list = await _scheduleStudentService.GetStudentID(studentID);

                if (list == null)
                {
                    return NotFound("StudentID không tồn tại, vui lòng xem lại StudentID");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet("GetByStudentID/{id}")]
        public async Task<ActionResult<ScheduleStudent>> GetByID(int id)
        {
            try
            {
                var list = await _scheduleStudentService.GetScheduleStudentByID(id);

                if (list == null)
                {
                    return NotFound("ScheduleStudentID không tồn tại, vui lòng kiểm tra lại ScheduleStudentID!!!!");
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
        public async Task<ActionResult> CreateScheduleStudent(ScheduleStudentDTO scheduleStudentDTO)
        {
            try
            {
                await _scheduleStudentService.CreateScheduleStudent(scheduleStudentDTO);
                return Ok(scheduleStudentDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPut("Update/{id}/{studentID}")]
        public async Task<ActionResult> EditScheduleStudent(int id, string studentID, UpdateScheduleStudentDTO updateScheduleStudentDTO)
        {
            try
            {
                var list = await _scheduleStudentService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ScheduleStudentID không tồn tại, vui lòng kiểm tra lại ScheduleStudentID!!!!");
                }
                await _scheduleStudentService.EditScheduleStudent(id, studentID, updateScheduleStudentDTO);
                return Ok(updateScheduleStudentDTO);
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
                var list = await _scheduleStudentService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("ScheduleStudentID không tồn tại, vui lòng kiểm tra lại ScheduleStudentID!!!!");
                }

                await _scheduleStudentService.DeleteScheduleStudent(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
