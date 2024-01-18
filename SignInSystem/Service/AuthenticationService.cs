#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SignInSystem.Context;
using SignInSystem.DTO.Authentication;
using SignInSystem.Entity;
using SignInSystem.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SignInSystem.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private Account _account;
        private readonly SignInSystemContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticationService(SignInSystemContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<dynamic> CheckLogin(AuthenticationDTO account)
        {
            var acc = await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.Email == account.Email);
            
            if(acc != null)
            {
                if (account.Password != acc.Password)
                {
                    throw new BadHttpRequestException("Wrong password!");
                }
            }
            else
            {
                var stu = await _context.Students.Include(s => s.Role).FirstOrDefaultAsync(s => s.Email == account.Email);
                
                if (stu != null)
                {
                    if (account.Password != stu.Password)
                    {
                        throw new BadHttpRequestException("Wrong password!");
                    }
                }
                else
                {
                    var teacher = await _context.Teachers.Include(s => s.Role).FirstOrDefaultAsync(t => t.Email == account.Email);

                    if(teacher != null)
                    {
                        if (account.Password != teacher.Password)
                        {
                            throw new BadHttpRequestException("Wrong password!");
                        }
                    }

                    else
                    {
                        throw new BadHttpRequestException("Check Your Email and Password!!!!");
                    }
                    return teacher;
                }
                return stu;
            }
            return acc;
        }

        public string CreateTokenAccount(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.PostalCode, account.AccountID + ""),
                new Claim(ClaimTypes.Name, account.AccountName),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role.RoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenSecret").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
            );
 
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string CreateTokenStudent(Student student)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.PostalCode, student.StudentID + ""),
                new Claim(ClaimTypes.Name, student.StudentName ),
 
                new Claim(ClaimTypes.Email, student.Email),
                new Claim(ClaimTypes.Role, student.Role.RoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenSecret").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string CreateTokenTeacher(Teacher teacher)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.PostalCode, teacher.TeacherID + ""),
                new Claim(ClaimTypes.Name, teacher.TeacherName),
                new Claim(ClaimTypes.PostalCode, teacher.TaxCode),
                new Claim(ClaimTypes.Email, teacher.Email),
                new Claim(ClaimTypes.Role, teacher.Role.RoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenSecret").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RefreshDTO GenerateRefreshToken()
        {
            var refreshToken = new RefreshDTO
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddHours(1),
                Created = DateTime.Now
            };
            return refreshToken;
        }

        public Account SetRefreshToken(RefreshDTO newRefreshToken, HttpResponse response)
        {
            _account = new Account();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            _account.RefreshToken = newRefreshToken.Token;
            _account.TokenCreated = newRefreshToken.Created;
            _account.TokenExpires = newRefreshToken.Expires;

            return _account;
        }

        public async Task<dynamic> ForgotPassword(string email, ForgotPasswordDTO account)
        {
            var acc = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email); 
            
            
            if (acc != null)
            {
                acc.Password = account.NewPassword;

                _context.Accounts.Update(acc);
                await _context.SaveChangesAsync();
            }
            else
            {
                var stu = await _context.Students.FirstOrDefaultAsync(s => s.Email == email);

                if (stu != null)
                {
                    stu.Password = account.NewPassword;

                    _context.Students.Update(stu);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var teacher = await _context.Teachers.FirstOrDefaultAsync(t => t.Email == email);

                    if (teacher != null)
                    {
                        teacher.Password = account.NewPassword;

                        _context.Teachers.Update(teacher);
                        await _context.SaveChangesAsync();
                    }

                    else
                    {
                        throw new BadHttpRequestException("Email bạn không tồn tại trong hệ thống, vui lòng kiểm tra lại EMAIL!!!!");
                    }
                    return teacher;
                }
                return stu;
            }
            return acc;
        }
    }
}
