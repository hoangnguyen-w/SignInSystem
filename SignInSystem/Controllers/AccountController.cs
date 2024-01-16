using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO;
using SignInSystem.Entity;
using SignInSystem.Interface;

namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin, Staff")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet("Get")]
        public async Task<ActionResult<List<Account>>> GetAll()
        {
            try
            {
                var list = await _accountService.GetAll();

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
        public async Task<ActionResult<List<Account>>> GetByEmail(string email)
        {
            try
            {
                var list = await _accountService.GetAccountByEmail(email);

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

        [HttpGet("GetByRole/{roleid}")]
        public async Task<ActionResult<Account>> GetByRole(int roleid)
        {
            try
            {
                var list = await _accountService.GetAccountByRole(roleid);

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

        [HttpGet("GetByAccountID/{id}")]
        public async Task<ActionResult<Account>> GetByID(int id)
        {
            try
            {
                var list = await _accountService.GetAccountByID(id);

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

        [HttpPost("Create")]
        public async Task<ActionResult> CreateAccount(RegisterAccountDTO accDTO)
        {
            try
            {
                await _accountService.CreateAccount(accDTO);
                return Ok(accDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditAccount(int id, RegisterAccountDTO accDTO)
        {
            try
            {
                await _accountService.EditAccount(id, accDTO);
                return Ok(accDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            try
            {
                var list = await _accountService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound();
                }

                await _accountService.DeleteAccount(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
