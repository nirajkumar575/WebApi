using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data.Interface
{
    public interface IUser
    {
        Task<IEnumerable<Models.User>> GetUser();

        Task<Models.User> GetById(int Id);
        Task<Models.User> Create(Models.User user);
        Task Update(Models.User user);
        Task Delete(int Id);
    }
}
