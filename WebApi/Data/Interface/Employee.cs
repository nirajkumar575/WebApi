using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.Interface
{
    public class Employee : IEmployee
    {
        ApplicationDbContext _context = null;
        public Employee(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Models.Employee> Create(Models.Employee employee)
        {
            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(int Id)
        {
            var toDelete = await _context.employees.FindAsync(Id);
            _context.employees.Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Employee>> GetAllEmployee()
        {
            return await _context.employees.ToListAsync();
        }

        //public async Task<IEnumerable<Models.Employee>> InsertMultiple(Models.Employee employees)
        //{
        //    var a = await _context.employees.AddAsync(employees);
        //}

        public async Task Update(Models.Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
