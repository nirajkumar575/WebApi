using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Interface;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUser _user = null;
        public UserApiController(IUser user)
        {
            _user = user;
        }
        [HttpGet("getuser")]
        public async Task<IEnumerable<Models.User>> GetUser()
        {
            return await _user.GetUser();
        }
        [HttpPost("create")]
        public async Task<Models.User> Create(Models.User user)
        {
            return await _user.Create(user);
        }
        [HttpGet("getbyid")]
        public async Task<Models.User> GetById(int Id)
        {
            return await _user.GetById(Id);
        }
        [HttpPost("update")]
        public async Task Update(Models.User user)
        {
            await _user.Update(user);
        }
        [HttpPost("delete")]
        public async Task Delete(int Id)
        {
            await _user.Delete(Id);
        }
    }
}

