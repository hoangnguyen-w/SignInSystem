using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignInSystem.DTO;
using SignInSystem.Entity;
using SignInSystem.Interface;
#nullable disable
namespace SignInSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin, Staff")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Role>>> GetAll()
        {
            try
            {
                var list = await _roleService.GetAll();

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

        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<List<Account>>> GetByEmail(string name)
        {
            try
            {
                var list = await _roleService.GetRoleByName(name);

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

        [HttpGet("GetByRoleID/{id}")]
        public async Task<ActionResult<Account>> GetByID(int id)
        {
            try
            {
                var list = await _roleService.GetRoleByID(id);

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
        public async Task<ActionResult> CreateRole(RoleDTO roleDTO)
        {
            try
            {
                await _roleService.CreateRole(roleDTO);
                return Ok(roleDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditRole(int id, RoleDTO roleDTO)
        {
            try
            {
                await _roleService.EditRole(id, roleDTO);
                return Ok(roleDTO);
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
                var list = await _roleService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound();
                }

                await _roleService.DeleteRole(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
