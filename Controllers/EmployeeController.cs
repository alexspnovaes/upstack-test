using Microsoft.AspNetCore.Mvc;
using upstack_test.Interfaces;
using upstack_test.ViewModels;

namespace upstack_test.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/employess")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("search")]
        public IActionResult SearchEmployeesByName([FromQuery] string query)
        {
            return Ok(_employeeService.SearchEmployeesByName(query));
        }


        [HttpGet("all")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpPost]
        public IActionResult Save([FromBody] EmployeeViewModel employee)
        {
            _employeeService.Save(employee);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromQuery] int id, [FromBody] EmployeeViewModel employee)
        {
            var result = _employeeService.FindEmployeeById(id);
            if (result == null)
            {
                return BadRequest("Id not found");
            }

            result.Email = employee.Email;
            result.UserName = employee.UserName;
            result.RoleId = employee.RoleId; //can check if this role exists...
            result.Name = employee.Name;            

            _employeeService.Update(employee);
            return Ok();
        }
    }
}
