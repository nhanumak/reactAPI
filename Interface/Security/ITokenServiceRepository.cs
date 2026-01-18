using System.Security.Claims;

namespace React_API.Interface.Security
{
    public interface ITokenServiceRepository
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims, IConfiguration config);

        public string GenerateRefreshToken();
    }
}
