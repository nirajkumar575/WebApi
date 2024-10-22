using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class OAuth : IOAuth
{
    private readonly IServiceCollection _services=null;
    private readonly IConfiguration _configuration=null;
    public OAuth(IServiceCollection services,IConfiguration configuration)
    {
        _services=services;
        _configuration=configuration;
    }
    public void Services()
    {
        _services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = "Google";
        })
        .AddCookie()
        .AddGoogle("Google", options =>
        {
            options.ClientId = _configuration["Authentication:Google:ClientId"];
            options.ClientSecret = _configuration["Authentication:Google:ClientSecret"];
            options.CallbackPath = "/signin-google";
        });
    _services.AddControllersWithViews();

    }
}