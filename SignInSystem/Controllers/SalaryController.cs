using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Salary;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class SalaryController : Controller
    {
        private readonly ISalaryService _salaryService;
        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet("GetBySalaryID/{id}")]
        public async Task<ActionResult<Salary>> GetByID(int id)
        {
            try
            {
                var list = await _salaryService.GetSalaryByID(id);

                if (list == null)
                {
                    return NotFound("SalaryID không tồn tại, vui lòng kiểm tra lại SalaryID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff, Teacher")]
        [HttpGet("GetSalaryTeacherByID/{teacherID}")]
        public async Task<ActionResult<Salary>> GetSalaryTeacherByID(string teacherID)
        {
            try
            {
                var list = await _salaryService.GetSalaryTeacherByID(teacherID);

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

        [Authorize(Roles = "Admin, Staff")]
        [HttpPost("Create")]
        public async Task<ActionResult> CreateSalary(SalaryDTO salaryDTO)
        {
            try
            {
                await _salaryService.CreateSalary(salaryDTO);
                return Ok(salaryDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditRole(int id, SalaryDTO salaryDTO)
        {
            try
            {
                var list = await _salaryService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("SalaryID không tồn tại, vui lòng kiểm tra lại SalaryID!!!!");
                }
                await _salaryService.EditSalary(id, salaryDTO);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpDelete("Delete/{id}/{teacherID}")]
        public async Task<ActionResult> DeleteRole(int id, string teacherID)
        {
            try
            {
                var list = await _salaryService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("SalaryID không tồn tại, vui lòng kiểm tra lại SalaryID!!!!");
                }

                await _salaryService.DeleteSalary(id, teacherID);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
