using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Student;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin, Staff")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            try
            {
                var list = await _studentService.GetAll();

                if (list == null)
                {
                    return NotFound("Sever bị sập rồi đợi tý nhé!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("SearchStudentIDNameEmail/{search}")]
        public async Task<ActionResult<List<Student>>> Search(string search)
        {
            try
            {
                var list = await _studentService.SearchStudentNameEmailID(search);

                if (list == null)
                {
                    return NotFound("Ký tự không tồn tại, vui lòng kiểm tra lại !!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllNewStudent")]
        public async Task<ActionResult<List<Student>>> GetAllNewStudent()
        {
            try
            {
                var list = await _studentService.GetAllNewStudent();

                if (list == null)
                {
                    return NotFound();
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<ActionResult<List<Student>>> GetByEmail(string email)
        {
            try
            {
                var list = await _studentService.GetStudentByEmail(email);

                if (list == null)
                {
                    return NotFound("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<List<Student>>> GetByName(string name)
        {
            try
            {
                var list = await _studentService.GetStudentByName(name);

                if (list == null)
                {
                    return NotFound("Student Name không tồn tại, vui lòng kiểm tra lại Student Name!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByStudentID/{id}")]
        public async Task<ActionResult<Student>> GetByID(string id)
        {
            try
            {
                var list = await _studentService.GetStudentByID(id);

                if (list == null)
                {
                    return NotFound("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateStudent(RegisterStudentDTO registerStudentDTO)
        {
            try
            {
                await _studentService.CreateStudent(registerStudentDTO);
                return Ok(registerStudentDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("CreateStudentInClass")]
        public async Task<ActionResult> CreateStudentInClass(string studentID, string classID)
        {
            try
            {
                var checkStudent = await _studentService.FindIDToResult(studentID);
                var checkCLass = await _studentService.FindClassID(classID);

                if (checkStudent == null)
                {
                    return NotFound("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
                }
                else
                {
                    if (checkCLass == null)
                    {
                        return NotFound("ClassID không tồn tại, vui lòng kiểm tra lại ClassID!!!!");
                    }
                    else
                    {
                        await _studentService.CreateStudenInClass(studentID, classID);
                        return Ok();
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditStudent(string id, UpdateStudentDTO updateStudentDTO)
        {
            try
            {
                var list = await _studentService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
                }

                await _studentService.EditStudent(id, updateStudentDTO);
                return Ok(updateStudentDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("DeleteStudentInClass")]
        public async Task<ActionResult> DeleteStudentInClass(string studentID, string classID)
        {
            try
            {

                await _studentService.DeleteStudentInClass(studentID, classID);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteStudent(string id)
        {
            try
            {
                var list = await _studentService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound("StudentID không tồn tại, vui lòng kiểm tra lại StudentID!!!!");
                }

                await _studentService.DeleteStudent(id);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
