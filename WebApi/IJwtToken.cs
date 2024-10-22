using System.Threading.Tasks;

public interface IJwtToken
{
    string GenerateJwtToken(LoginModel login);
}