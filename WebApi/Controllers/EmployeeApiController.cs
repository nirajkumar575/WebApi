using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly IEmployee _employee = null;
        public EmployeeApiController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet("getemployee")]
        public async Task<IEnumerable<Models.Employee>> GetEmployee()
        {
            return await _employee.GetAllEmployee();
        }
        [HttpPost("insertemployee")]
        public async Task<Models.Employee> InsertEmployee(Models.Employee emp)
        {
            return await _employee.Create(emp);
        }
        [HttpPut("updateemployee")]
        public async Task UpdateEmployee(Models.Employee employee)
        {
            await _employee.Update(employee);
        }
        [HttpDelete("deleteemployee")]
        public async Task DeleteEmployee(int id)
        {
            await _employee.Delete(id);
        }
    }
}
