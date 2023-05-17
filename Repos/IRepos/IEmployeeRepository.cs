using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Models.DTO;

namespace WebApiDemo.Repos.IRepos
{
    public interface IEmployeeRepository
    {
        Task<ActionResult<List<EmployeeDto>>> Get();

        Task<ActionResult<Employee>> NewEmp(Employee employee);

    }
}
