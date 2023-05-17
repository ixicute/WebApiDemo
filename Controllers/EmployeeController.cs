using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Models.DTO;
using WebApiDemo.Repos.IRepos;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository empRepo;

        public EmployeeController(IEmployeeRepository _empRepo)
        {
            empRepo = _empRepo;
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployeeList()
        {
            var allEmps = await empRepo.Get();
            return Ok(allEmps);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] NewEmpDto emp)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    FK_Role = 2,
                    Address = emp.Address
                };

                var result = await empRepo.NewEmp(newEmployee);

                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
