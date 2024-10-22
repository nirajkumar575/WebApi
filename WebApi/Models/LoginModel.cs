using Microsoft.AspNetCore.Identity;
public class LoginModel : IdentityUser
{
    public string Password { get; set; }
}