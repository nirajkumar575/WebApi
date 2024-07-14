using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data.Interface
{
    public class User : IUser
    {
        ApplicationDbContext _context = null;
        public User(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Models.User> Create(Models.User user)
        {
            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int Id)
        {
            var toDelete = await _context.users.FindAsync(Id);
            _context.users.Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Models.User> GetById(int Id)
        {
            return await _context.users.FindAsync(Id);
        }

        public async Task<IEnumerable<Models.User>> GetUser()
        {
            return await _context.users.ToListAsync();
        }

        public async Task Update(Models.User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
