using Microsoft.AspNetCore.Mvc;
using upstack_test.Interfaces;
using upstack_test.ViewModels;
using Microsoft.EntityFrameworkCore;
using upstack_test.Models;

namespace upstack_test.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("search")]
        public IActionResult SearchRolesByName([FromQuery]string code)
        {
            return Ok(_roleService.SearchRoleByCode(code));
        }

        
        [HttpGet("all")]
        public IActionResult GetRoles()
        {
            return Ok(_roleService.GetRoles());
        }

        [HttpPost]
        public IActionResult Save([FromBody] RoleViewModel role)
        {
            _roleService.Save(role);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromQuery] int id, [FromBody] RoleViewModel role)
        {
            var result =  _roleService.FindRoleById(id);
            if (result == null) {
                return BadRequest("Id not found");
            }

            result.RoleName = role.RoleName;
            result.RoleCode = role.RoleCode;

            _roleService.Update(role);
            return Ok();
        }
    }
}
