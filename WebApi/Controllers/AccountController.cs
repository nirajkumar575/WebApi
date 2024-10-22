using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGenerateJwtToken _generateJwtToken = null;
        
        public AccountController(UserManager<IdentityUser> userManager, IGenerateJwtToken generateJwtToken)
        {
            _userManager = userManager;
            _generateJwtToken = generateJwtToken;
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
        public IActionResult LoginByJwt([FromBody] LoginModel login)
        {
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var token = _generateJwtToken.GeneratejwtToken(login);
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
        [HttpGet]
        public IActionResult LoginByOAuth(string returnUrl = "/")
        {
            var properties = new AuthenticationProperties { RedirectUri = returnUrl };
            return Challenge(properties, "Google");
        }

        [HttpGet]
        public async Task<IActionResult> LogoutByOAuth()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
