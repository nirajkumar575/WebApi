using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtToken _jwtToken=null;
        
        public AccountController(UserManager<IdentityUser> userManager, IJwtToken jwtToken)
        {
            _userManager = userManager;
            _jwtToken=jwtToken;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginModel model)
        {
            await _userManager.CreateAsync(model);

            return Ok(new {status="success",message="User Inserted Successfully !!" });
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var token = _jwtToken.GenerateJwtToken(login);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private LoginModel AuthenticateUser(LoginModel login)
        {
            if (login.UserName == "Admin" && login.Password == "Admin")
            {
                return new LoginModel { UserName = "Niraj", Email = "niraj.kumar575@gmail.com" };
            }

            return null;
        }

    }
}
