using Microsoft.IdentityModel.Tokens;
using NetCodeUtility_Sample.JwtAuth.Models;
using System.Security.Cryptography;

namespace NetCodeUtility_Sample.JwtAuth.JwtSigning;

/// <summary>
/// 非對稱加密
/// </summary>
public class JwtRSA : BaseJwtAuth
{
    private string RSA_PrivateKey { get; set; }
    private string RSA_PublicKey { get; set; }

    public JwtRSA(JwtAuthSettings settings) : base(settings)
    {
        if (settings.RasPrivateKey == null)
            throw new ArgumentNullException(nameof(settings.RasPrivateKey));
        if (settings.RasPublicKey == null)
            throw new ArgumentNullException(nameof(settings.RasPublicKey));

        RSA_PrivateKey = settings.RasPrivateKey;
        RSA_PublicKey = settings.RasPublicKey;
    }

    protected override SigningCredentials GetSigningCredentials()
    {
        var privateKey = Convert.FromBase64String(RSA_PrivateKey);
        using var rsa = RSA.Create();
        rsa.ImportPkcs8PrivateKey(privateKey, out _);
        var rasKey = new RsaSecurityKey(rsa.ExportParameters(true));

        return new SigningCredentials(rasKey, SecurityAlgorithms.RsaSha256)
        {
            CryptoProviderFactory = new CryptoProviderFactory
            {
                CacheSignatureProviders = false
            }
        };
    }

    protected override SecurityKey GetSecurityKey()
    {
        var publicKey = Convert.FromBase64String(RSA_PublicKey);
        RSA rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(publicKey, out _);
        var rsaKey = new RsaSecurityKey(rsa.ExportParameters(false));

        return rsaKey;
    }
}