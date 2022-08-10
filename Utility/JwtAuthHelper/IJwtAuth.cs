using System.Security.Claims;

namespace NetCodeUtility_Sample.JwtAuth;

public interface IJwtAuth
{
    /// <summary>
    /// «Ø¥ßJwt
    /// </summary>
    string CreateJwt<TClaims>(TClaims claims) where TClaims : class;

    /// <summary>
    /// ÅçÃÒJwt
    /// </summary>
    ClaimsPrincipal? ValidateToken(string jwt);
}