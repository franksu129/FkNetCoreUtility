using Microsoft.VisualStudio.TestTools.UnitTesting;
using FkNetCoreUtility.FkJwtAuth.Models;
using FkNetCoreUtility.FkJwtAuth.Extension;
using FkNetCoreUtility.FkJwtAuth.JwtSigning;
using FkNetCoreUtility.FkJwtAuth;
using FkUtilityTests.Models;

namespace FkUtilityTests.FkJwtAuthTest;

[TestClass]
public class JwtAuthTest
{
    /// <summary>
    /// RSA Token建立 並 驗證取得Token資料
    /// </summary>
    [TestMethod]
    public void CreateJwtRSATest()
    {
        IJwtAuth jwtAuth = new JwtRSA(new JwtAuthSettings
        {
            Issuer = "From Test",
            ExpiryMinutes = 480,
            RasPrivateKey = "MIIEvwIBADANBgkqhkiG9w0BAQEFAASCBKkwggSlAgEAAoIBAQCgr/xVrq/J3EQBUNSCmPZWrEBZ9vERaq/2O4Aad2vUa47/jFcXMDVsOTsXiygI2jeSawEYkSH/o9brPfovlTEfSU+rZLL5R9SiNt6+TGwiKI9TwB+cyum+2CjEAiRseHT8O937xw6RP+svjugXT7pkOIKw9y5bq9s2YnzL7HcLtGnTw98cObxe+2lWxXj8ittfarIkpbZR+VZ94b7uxZPAyNmUtsYa4qCZ8wnny6969Ch4gFOyX4OSXb/02rUyBo2Svcuv2t+tyOh29JXWVLzJ7uoEJV5C+5H+IzPWn4KeCpbcpvjDlqi2CKKtIlraXvtpjg/DDJnw2vTHV+E0csxlAgMBAAECggEBAI5JR3fXp3FnyhAgMw0xxXAaNyFyuSRjBE1Vgqns9V6zn3xKGRQ/bA7Y3qqKXnj4Qh01A1NtsF1eBwFncBKSWV0K3bE3CgQSxwac78Ayi83zfHb8uQFt7G1Bm1d1Tit+vphbqsU4Dn4vy2HheUKrJrF4GMH7HuGt2/7cVwV77i49u/QRINmft95cM8Xh50US+UlQCv9wKj4jDgyEtIeLFkFybnP9koXKzjc2PUpwm6ChWKifR/ON3Y6brR4xYo4w9UUXI86jQPDJa8nspcMNkztI0TJhWv4Th4M8BGo6l+L5D1wrSYOMOkziZ8+bXalUfL3V3mJ1I+U3inY5aDCyeEECgYEAzumfdLsMkEZm5PVCs9TSkP6BVBjtVxKBVhAE9khc2USGGj57PWHJ6iN6rJ1kT6DUbrBvfL2nhZxrtwdYub94+luyi4jeKCKiDy9FJKVO8SGelE48K99YTiZj9pyEjfjoBLChBase4IbTxL8Lqw053MUQJbIXHlzuTGuzh/8D4C8CgYEAxs77LJK46uMPrEAZwc6ZvGJsWRt7NJ/BEhOTg+uCpER2e/k5LRfUOxO051h1dskgiB5aK+yBbWzDrngQ+j/cHgXLMZZDcRXMlv0vMk3ySYlGeAjVTespRmyosJm/eO0NvTQp69SvIKdZ5tCAN+7NklDXSZjiQae1HHmNNGQcg6sCgYEAkXrjuZBWig5mBC+JwaUuk/HN/tIz9he1xkwnIP7KAZ1TaJprzkG2VSCy/TEAuZgMJPN6v8sdQS008xCASsGcjvLwO3l1MeT/6wtCYzyzn4kS1ZWYawRzMyd8+4UbEjNi9wE1hiXF5PoHZXsp+g+nklkgPFDWPmv6xNKo/ULJd9MCgYEAkyNtUjflFDKozttCNOYrcfmGJwznyrLRugczDlengNwKtQZnArC4KmETaoVVqmyA3z1Xj1qjD9GHogDKz+ujhbTUBgcoMvHnUXhhDeISh8pJlV00QU7iZXTWBJ5Fz8HigT2yKRBn7MrvBp0ZyEu9aaTbMWUtT1pH+KMdlsDhObECgYBKDFgN8mKV2lBwXJoKWnjAdgJP4qKF0pLFFuipnzY/pHaZVa5JfEH+O3bL3py2F/kNfjCyTLBhDAmMaI2VHMTZTXiVrA7P2x+Ugjfm6+fDUkkzo3tKe7i/wTN6wvZxs8wxvb6QFCk9YIjCfqVYcTwOytQm5oxXpHRgq6zbfJ79aA==",
            RasPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoK/8Va6vydxEAVDUgpj2VqxAWfbxEWqv9juAGndr1GuO/4xXFzA1bDk7F4soCNo3kmsBGJEh/6PW6z36L5UxH0lPq2Sy+UfUojbevkxsIiiPU8AfnMrpvtgoxAIkbHh0/Dvd+8cOkT/rL47oF0+6ZDiCsPcuW6vbNmJ8y+x3C7Rp08PfHDm8XvtpVsV4/IrbX2qyJKW2UflWfeG+7sWTwMjZlLbGGuKgmfMJ58uvevQoeIBTsl+Dkl2/9Nq1MgaNkr3Lr9rfrcjodvSV1lS8ye7qBCVeQvuR/iMz1p+CngqW3Kb4w5aotgiirSJa2l77aY4PwwyZ8Nr0x1fhNHLMZQIDAQAB"
        });

        var token = jwtAuth.CreateJwt(new JwtCustClaims
        {
            UserId = 1
        });

        var ClaimsPrincipal = jwtAuth.ValidateToken(token);

        Assert.IsNotNull(ClaimsPrincipal);

        var cusClaims = ClaimsPrincipal.ToJwtInfo<JwtCustClaims>();
        Assert.AreEqual(cusClaims.UserId, 1u);
    }

    /// <summary>
    /// HmacSha256 Token建立 並 驗證取得Token資料
    /// </summary>
    [TestMethod]
    public void CreateJwtHmacSha256Test()
    {
        IJwtAuth jwtHelper = new JwtHmacSha256(new JwtAuthSettings
        {
            Issuer = "From Test",
            ExpiryMinutes = 480,
            HamcSecretKey = "bGoa+V7g/yqDXvKRqq+JTFn4uQZbPiQJo4pf9RzJ"
        });

        var token = jwtHelper.CreateJwt(new JwtCustClaims
        {
            UserId = 1
        });

        var ClaimsPrincipal = jwtHelper.ValidateToken(token);
        Assert.IsNotNull(ClaimsPrincipal);

        var cusClaims = ClaimsPrincipal.ToJwtInfo<JwtCustClaims>();
        Assert.AreEqual(cusClaims.UserId, 1u);
    }
}