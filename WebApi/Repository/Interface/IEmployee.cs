using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

public interface IEmployee
{
    Task<IEnumerable<EmployeeModel>> GetAllEmployee();
    Task<EmployeeModel> GetEmployeeById(int id);
    Task<EmployeeModel> CreateEmployee(EmployeeModel model);
    Task<EmployeeModel> UpdateEmployee(EmployeeModel model);
    Task<EmployeeModel> DeleteEmployee(EmployeeModel model);
}