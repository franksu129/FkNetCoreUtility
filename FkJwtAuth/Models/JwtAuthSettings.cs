namespace FkNetCoreUtility.FkJwtAuth.Models;

public struct JwtAuthSettings
{
    /// <summary>
    /// 簽章發行人 Issuer
    /// </summary>
    public string? Issuer { get; set; }

    /// <summary>
    /// 憑證有效時間(分鐘)
    /// </summary>
    public int? ExpiryMinutes { get; set; }

    /// <summary>
    /// Rsa私鑰
    /// </summary>
    public string? RasPrivateKey { get; set; }

    /// <summary>
    /// Rsa公鑰
    /// </summary>
    public string? RasPublicKey { get; set; }

    /// <summary>
    /// HamcSHA256
    /// </summary>
    public string? HamcSecretKey { get; set; }
}