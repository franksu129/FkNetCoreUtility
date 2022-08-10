using Microsoft.IdentityModel.Tokens;
using NetCodeUtility_Sample.JwtAuth.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;

namespace NetCodeUtility_Sample.JwtAuth;

public abstract class BaseJwtAuth : IJwtAuth
{
    /// <summary>
    /// JTW 逾期時間
    /// </summary>
    public int ExpiryMinutes { get; set; }

    /// <summary>
    /// 發行人
    /// </summary>
    public string Issuer { get; set; }

    public BaseJwtAuth(JwtAuthSettings settings)
    {
        Issuer = settings.Issuer ?? "";
        ExpiryMinutes = settings.ExpiryMinutes ?? 480;
    }

    public string CreateJwt<TClaims>(TClaims claims) where TClaims : class
    {
        var now = DateTime.Now;

        // 產生Jwt
        var jwt = new JwtSecurityToken(
            issuer: Issuer,
            claims: GetJwtClaims(claims, now),
            notBefore: now,
            expires: now.AddMinutes(ExpiryMinutes),
            signingCredentials: GetSigningCredentials()
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return token;
    }

    public ClaimsPrincipal? ValidateToken(string jwt)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                // 驗證發簽
                ValidIssuer = Issuer,
                // 驗證時間
                ValidateLifetime = true,
                // 驗證簽名
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(),
                // 驗證接收人員
                ValidateAudience = false,
                ValidAudience = "",
                CryptoProviderFactory = new CryptoProviderFactory()
                {
                    // 不暫存
                    CacheSignatureProviders = false
                }
            };

            return handler.ValidateToken(jwt, validationParameters, out _) ?? null;
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// 取得簽章 (加簽用)
    /// </summary>
    protected abstract SigningCredentials GetSigningCredentials();

    /// <summary>
    /// 取得簽章金鑰 (驗簽用)
    /// </summary>
    protected abstract SecurityKey GetSecurityKey();

    /// <summary>
    /// 取得JWT Claim資料
    /// </summary>
    private static List<Claim> GetJwtClaims<TClaims>(TClaims cusClaimsData, DateTime nowTime)
        where TClaims : class
    {
        var unixTimeSeconds = new DateTimeOffset(nowTime).ToUnixTimeSeconds();
        var jwtClaims = new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Iat, unixTimeSeconds.ToString(), ClaimValueTypes.Integer64),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var props = cusClaimsData.GetType().GetProperties();

        foreach (PropertyInfo item in props)
        {
            var jsonPropertyName = item.GetCustomAttribute<JsonPropertyAttribute>()?.PropertyName;

            if (jsonPropertyName == null)
                continue;

            var typeCode = Type.GetTypeCode(item.PropertyType);

            var value = item.GetValue(cusClaimsData);

            switch (typeCode)
            {
                case TypeCode.String:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt32:
                    if (value != null)
                        jwtClaims.Add(new Claim(jsonPropertyName, value.ToString()));
                    break;

                default:
                    break;
            }
        }

        return jwtClaims;
    }
}