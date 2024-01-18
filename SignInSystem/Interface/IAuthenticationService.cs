using SignInSystem.DTO.Authentication;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IAuthenticationService
    {
        Task<dynamic> CheckLogin(AuthenticationDTO account);

        //Task<Account> CheckLogin(AuthenticationDTO account);

        string CreateTokenAccount(Account account);

        string CreateTokenStudent(Student student);

        string CreateTokenTeacher(Teacher teacher);

        RefreshDTO GenerateRefreshToken();

        Account SetRefreshToken(RefreshDTO newRefreshToken, HttpResponse response);
    }
}
