using System.Threading.Tasks;

public interface IGenerateJwtToken
{
    string GeneratejwtToken(LoginModel login);
}