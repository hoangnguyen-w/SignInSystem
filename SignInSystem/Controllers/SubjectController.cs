using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Subject;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff, Teacher")]
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Subject>>> GetAll()
        {
            try
            {
                var list = await _subjectService.GetAll();

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

        [HttpGet("GetBySubjectID/{id}")]
        public async Task<ActionResult<Subject>> GetByID(int id)
        {
            try
            {
                var list = await _subjectService.GetSubjectByID(id);

                if (list == null)
                {
                    return NotFound("SubjectID không tồn tại, vui lòng kiểm tra lại SubjectID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetBySubjectName/{name}")]
        public async Task<ActionResult<Subject>> GetByName(string name)
        {
            try
            {
                var list = await _subjectService.GetSubjectByName(name);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateSubject(SubjectDTO subjectDTO)
        {
            try
            {
                await _subjectService.CreateSubject(subjectDTO);
                return Ok(subjectDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditSubject(int id, SubjectDTO subjectDTO)
        {
            try
            {
                var list = await _subjectService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("SubjectID không tồn tại, vui lòng kiểm tra lại SubjectID!!!!");
                }
                await _subjectService.EditSubject(id, subjectDTO);
                return Ok(subjectDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                var list = await _subjectService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("SubjectID không tồn tại, vui lòng kiểm tra lại SubjectID!!!!");
                }

                await _subjectService.DeleteSubject(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
