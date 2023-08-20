using System.Data;
using System.Security.Claims;

namespace DTI.Services.Interfaces
{
    public interface ITokenRepository
    {
        DateTime GetRefreshTokenExpiryTime();
        string CreateToken(string id, string identityNumber, string name, DateTime expiryTime);
        List<Claim> CreateClaims(string id, string identityNumber, string name);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
        string GenerateRefreshToken();
    }
}
