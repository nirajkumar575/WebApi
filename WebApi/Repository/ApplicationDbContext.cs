using Microsoft.EntityFrameworkCore;
using WebApi.Models;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<UserModel> users {get; set;}
    public DbSet<EmployeeModel> employees {get; set;}
}