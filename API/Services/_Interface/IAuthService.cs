using System.Security.Claims;

namespace API.Services._Interface
{
    public interface IAuthService
    {
        public string CreateToken(IList<Claim> claims);
        public string DecodeToken(string token);
    }
}
