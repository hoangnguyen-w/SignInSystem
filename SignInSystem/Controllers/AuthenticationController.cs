using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO.Authentication;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private static Account account = new Account();
        private static Student student = new Student();
        private static Teacher teacher = new Teacher();
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthenticationDTO req)
        {
            try
            {
                var checklogin = await _authenticationService.CheckLogin(req);

                int check = checklogin.RoleID;

                if(check == 1 || check == 2)
                {
                    string token = _authenticationService.CreateTokenAccount(checklogin);

                    var refreshToken = _authenticationService.GenerateRefreshToken();
                    var setToken = _authenticationService.SetRefreshToken(refreshToken, Response);

                    account = checklogin;
                    account.RefreshToken = setToken.RefreshToken;
                    account.TokenExpires = setToken.TokenExpires;

                    TokenDTO dto = new TokenDTO();

                    dto.id = checklogin.AccountID + "";
                    dto.name = checklogin.AccountName;
                    dto.Email = checklogin.Email;
                    dto.Token = token;
                    dto.Role = checklogin.Role.RoleName;

                    return Ok(dto);
                }
                else if(check == 3)
                {
                    
                    string token3 = _authenticationService.CreateTokenTeacher(checklogin);

                    var refreshToken = _authenticationService.GenerateRefreshToken();
                    var setToken = _authenticationService.SetRefreshToken(refreshToken, Response);

                    teacher = checklogin;
                    account.RefreshToken = setToken.RefreshToken;
                    account.TokenExpires = setToken.TokenExpires;

                    TokenDTO dto = new TokenDTO();

                    dto.id = checklogin.TeacherID;
                    dto.name = checklogin.TeacherName;
                    dto.Email = checklogin.Email;
                    dto.Token = token3;
                    dto.Role = checklogin.Role.RoleName;

                    return Ok(dto);
                }

                else if (check == 4)
                {

                    string token4 = _authenticationService.CreateTokenStudent(checklogin);

                    var refreshToken = _authenticationService.GenerateRefreshToken();
                    var setToken = _authenticationService.SetRefreshToken(refreshToken, Response);

                    student = checklogin;
                    account.RefreshToken = setToken.RefreshToken;
                    account.TokenExpires = setToken.TokenExpires;

                    TokenDTO dto = new TokenDTO();

                    dto.id = checklogin.StudentID;
                    dto.name = checklogin.StudentName;
                    dto.Email = checklogin.Email;
                    dto.Token = token4;
                    dto.Role = checklogin.Role.RoleName;
                    return Ok(dto);

                }

                return NotFound();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("logout"), Authorize(Roles = "Admin, Staff, Student, Teacher")]
        public ActionResult Logout(string token)
        {
            try
            {
                token = "";
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
