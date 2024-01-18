using Microsoft.EntityFrameworkCore;
using SignInSystem.Context;
using SignInSystem.DTO.Account;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable

namespace SignInSystem.Service
{
    public class AccountService : IAccountService
    {
        private readonly SignInSystemContext _context;
        public AccountService(SignInSystemContext context)
        {
            _context = context;
        }   

        public async Task CreateAccount(RegisterAccountDTO registerAccountDTO)
        {
            Account acc = new Account();

            acc.Email = registerAccountDTO.Email;
            acc.Password = registerAccountDTO.Password;
            acc.RoleID = 2;

            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccount(int id)
        {
            var search = _context.Accounts.FirstOrDefault(a => a.AccountID == id);
            _context.Remove(search);
            await _context.SaveChangesAsync();
        }

        public async Task EditAccount(int id, UpdateAccountDTO updateAccountDTO)
        {
            var search = _context.Accounts.FirstOrDefault(a => a.AccountID == id);

            search.AccountName = updateAccountDTO.AccountName;
            search.Email = updateAccountDTO.Email;
            search.Password = updateAccountDTO.Password;

            _context.Accounts.Update(search);
            await _context.SaveChangesAsync();
        }
        public async Task<Account> FindIDToResult(int id)
        {
            var list = await _context.Accounts.FindAsync(id);
            return list;
        }
        public async Task<List<Account>> GetAccountByEmail(string email)
        {
            var list = await _context.Accounts.Where(a => a.Email.Trim().ToLower().Contains(email.Trim().ToLower())).ToListAsync();
            return list;
        }

        public async Task<List<Account>> GetAccountByID(int id)
        {
            var list = await _context.Accounts.Where(a => a.AccountID == id).ToListAsync();
            return list;
        }

        public async Task<List<Account>> GetAccountByRole(int RoleID)
        {
            var list = await _context.Accounts.Where(a => a.RoleID == RoleID).ToListAsync();
            return list;
        }

        public async Task<List<Account>> GetAll()
        {
            var list = await _context.Accounts.Include(a => a.Role).ToListAsync();
            return list;
        }
    }
}
