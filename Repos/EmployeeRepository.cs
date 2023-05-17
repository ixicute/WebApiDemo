using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;
using WebApiDemo.Models;
using WebApiDemo.Models.DTO;
using WebApiDemo.Repos.IRepos;

namespace WebApiDemo.Repos
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<ActionResult<List<EmployeeDto>>> Get()
        {
            List<EmployeeDto> empsList = new List<EmployeeDto>();

            var empsRole = await (from e in context.Employees
                                  join r in context.Roles on e.FK_Role equals r.RoleId
                                  select new
                                  {
                                      Id = e.EmployeeId,
                                      FirstName = e.FirstName,
                                      LastName = e.LastName,
                                      Role = r.RoleName,
                                      Ad = e.Address

                                  }).ToListAsync();

            foreach (var item in empsRole)
            {
                var empList = new EmployeeDto();

                empList.EmployeeId = item.Id;
                empList.FirstName = item.FirstName;
                empList.LastName = item.LastName;
                empList.Role = item.Role;
                empList.Address = item.Ad;
                empsList.Add(empList);
            }

            return empsList;
        }

        public async Task<ActionResult<Employee>> NewEmp(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return employee;
        }
    }
}
