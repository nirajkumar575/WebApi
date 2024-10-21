using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeeService = null;
        public EmployeeController(IEmployee employee)
        {
            this.employeeService = employee;
        }
        [HttpGet("getemployee")]
        public async Task<IEnumerable<EmployeeModel>> GetEmployee()
        {
            return await employeeService.GetAllEmployee();
        }
        [HttpPost("insertemployee")]
        public async Task<EmployeeModel> InsertEmployee(EmployeeModel employee)
        {
            return await employeeService.CreateEmployee(employee);
        }
        [HttpPut("updateemployee")]
        public async Task UpdateEmployee(EmployeeModel employee)
        {
            await employeeService.UpdateEmployee(employee);
        }
        [HttpDelete("deleteemployee")]
        public async Task DeleteEmployee(EmployeeModel employee)
        {
            await employeeService.DeleteEmployee(employee);
        }
    }
}
