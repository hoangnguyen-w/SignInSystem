using SignInSystem.DTO.Account;
using SignInSystem.Entity;

namespace SignInSystem.Interface
{
    public interface IAccountService
    {
        Task<List<Account>> GetAll();

        Task<List<Account>> GetAccountByID(int id);

        Task<List<Account>> GetAccountByEmail(string email);

        Task<List<Account>> GetAccountByRole(int RoleID);

        Task<Account> FindIDToResult(int id);

        Task CreateAccount(RegisterAccountDTO registerAccountDTO);

        Task EditAccount(int id, UpdateAccountDTO updateAccountDTO);

        Task ChangeRoleAccount(int id);

        Task DeleteAccount(int id);
    }
}
