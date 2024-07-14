using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Models.Employee>> GetAllEmployee();
        Task<Models.Employee> Create(Models.Employee employee);
        Task Update(Models.Employee employee);
        Task Delete(int Id);
        //Task<IEnumerable<Models.Employee>> InsertMultiple(IEnumerable<Models.Employee> employees);
    }
}
