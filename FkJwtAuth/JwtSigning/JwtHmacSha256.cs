using Microsoft.IdentityModel.Tokens;
using FkNetCoreUtility.FkJwtAuth.Models;
using System.Text;

namespace FkNetCoreUtility.FkJwtAuth.JwtSigning;

/// <summary>
/// 對稱式加密
/// </summary>
public class JwtHmacSha256 : BaseJwtAuth
{
    private string HamcSecretKey { get; set; }

    public JwtHmacSha256(JwtAuthSettings settings) : base(settings)
    {
        if (settings.HamcSecretKey == null)
            throw new ArgumentNullException(nameof(settings.HamcSecretKey));

        HamcSecretKey = settings.HamcSecretKey;
    }

    protected override SigningCredentials GetSigningCredentials()
    {
        var Key = Encoding.ASCII.GetBytes(HamcSecretKey);
        return new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature);
    }

    protected override SecurityKey GetSecurityKey()
    {
        var Key = Encoding.ASCII.GetBytes(HamcSecretKey);
        return new SymmetricSecurityKey(Key);
    }
}