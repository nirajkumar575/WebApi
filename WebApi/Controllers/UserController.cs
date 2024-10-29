using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser userService = null;
        public UserController(IUser user)
        {
            this.userService = user;
        }
        [HttpGet("getuser")]
        public async Task<IEnumerable<UserModel>> GetUser()
        {
            return await userService.AllUsers();
        }
        [HttpPost("create")]
        public async Task<UserModel> Create(UserModel user)
        {
            return await userService.CreateUser(user);
        }
        [HttpGet("getbyid")]
        public async Task<UserModel> GetById(int Id)
        {
            return await userService.GetUserById(Id);
        }
        [HttpPost("update")]
        public async Task Update(UserModel user)
        {
            await userService.UpdateUser(user);
        }
        [HttpPost("delete")]
        public async Task Delete(UserModel user)
        {
            await userService.DeleteUser(user);
        }
    }
}

