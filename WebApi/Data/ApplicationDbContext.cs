using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {          
        }
        public DbSet<Models.User> users { get; set; }

        public DbSet<Models.Employee> employees { get; set; }
        //public DbSet<IEnumerable<Models.Employee>> Employees { get; set; }
    }
}
