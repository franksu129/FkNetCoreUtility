using System.Security.Claims;

namespace NetCodeUtility_Sample.JwtAuth;

public interface IJwtAuth
{
    /// <summary>
    /// �إ�Jwt
    /// </summary>
    string CreateJwt<TClaims>(TClaims claims) where TClaims : class;

    /// <summary>
    /// ����Jwt
    /// </summary>
    ClaimsPrincipal? ValidateToken(string jwt);
}