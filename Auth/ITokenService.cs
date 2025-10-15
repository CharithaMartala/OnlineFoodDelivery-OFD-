using UserLogin.Model;

namespace UserLogin.Auth
{
    public interface ITokenService
    {
        string CreateToken(User us);
    }
}
