using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

public class Employee : IEmployee
{
    private readonly ApplicationDbContext dbContext=null;
    public Employee(ApplicationDbContext context)
    {
        this.dbContext=context;
    }
    public async Task<EmployeeModel> CreateEmployee(EmployeeModel model)
    {
        var employee= dbContext.employees.Add(model);
        await dbContext.SaveChangesAsync();
        return model;
    }

    public async Task<EmployeeModel> DeleteEmployee(EmployeeModel model)
    {
        var employee = dbContext.employees.Find(model.EmpId);
        if (employee != null)
        {
            dbContext.employees.Remove(employee);
            await dbContext.SaveChangesAsync();
        }
        return employee;
    }

    public async Task<IEnumerable<EmployeeModel>> GetAllEmployee()
    {
        return await dbContext.employees.ToListAsync();
    }

    public async Task<EmployeeModel> GetEmployeeById(int id)
    {
        var employee = await dbContext.employees.FindAsync(id);
        return  employee;
    }

    public async Task<EmployeeModel> UpdateEmployee(EmployeeModel model)
    {
        var employee= dbContext.employees.Find(model.EmpId);
       if (employee != null)
       {
        dbContext.employees.Update(model);
        await dbContext.SaveChangesAsync();
       }
       return model;
    }
}