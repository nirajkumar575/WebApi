using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

public class User : IUser
{
    private readonly ApplicationDbContext dbContext=null;
    public User(ApplicationDbContext context)
    {
        this.dbContext=context;
    }
    public async Task<IEnumerable<UserModel>> AllUsers()
    {
        return await dbContext.users.ToListAsync();
    }

    public async Task<UserModel> CreateUser(UserModel model)
    {
        var user= dbContext.users.Add(model);
        await dbContext.SaveChangesAsync();
        return model;
    }

    public async Task<UserModel> DeleteUser(UserModel model)
    {
        var user= dbContext.users.Find(model.Id);
        if (user != null)
        {
            dbContext.users.Remove(user);
            await dbContext.SaveChangesAsync();
        }
        return model;
    }

    public async Task<UserModel> GetUserById(int id)
    {
        var user = await dbContext.users.FindAsync(id);
        return  user;
    }

    public async Task<UserModel> UpdateUser(UserModel model)
    {
       var user= dbContext.users.Find(model.Id);
       if (user != null)
       {
        dbContext.users.Update(user);
        await dbContext.SaveChangesAsync();
       }
       return model;
    }
}