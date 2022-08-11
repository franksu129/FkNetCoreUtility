using System.Security.Claims;

namespace FkNetCoreUtility.FkJwtAuth;

public interface IJwtAuth
{
    /// <summary>
    /// 建立 JWT
    /// </summary>
    string CreateJwt<TClaims>(TClaims claims) where TClaims : class;

    /// <summary>
    /// 驗證JWT
    /// </summary>
    ClaimsPrincipal? ValidateToken(string jwt);
}