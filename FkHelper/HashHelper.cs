using System.Security.Cryptography;
using System.Text;

namespace FkHelper;

public static class HashHelper
{
    private static string _RunHash(HashAlgorithm transform, string msg)
    {
        byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
        var hashMsg = transform.ComputeHash(msgBytes);
        return BitConverter.ToString(hashMsg).Replace("-", "");
    }

    public static string HMACSHA256(string message, string key)
    {
        byte[] keyByte = Encoding.UTF8.GetBytes(key);
        using var hmacSHA256 = new HMACSHA256(keyByte);

        return _RunHash(hmacSHA256, message);
    }

    public static string HashSHA256(string message)
    {
        using var sha256 = SHA256.Create();
        return _RunHash(sha256, message);
    }

    public static string HashMD5(string message)
    {
        using var md5 = MD5.Create();
        return _RunHash(md5, message);
    }

}