using System.Security.Claims;

namespace FkNetCoreUtility.FkJwtAuth.Extension;

public static class ClaimsPrincipalExtension
{
    private static object? ConvertValue(TypeCode code, string value)
        => code switch
        {
            TypeCode.Int16 => Convert.ToInt16(value),
            TypeCode.Int32 => Convert.ToInt32(value),
            TypeCode.UInt32 => Convert.ToUInt32(value),
            TypeCode.Int64 => Convert.ToInt64(value),
            _ => value,
        };

    /// <summary>
    /// 轉換 Claims 資料對應回使用者資料
    /// </summary>
    public static TClaims ToJwtInfo<TClaims>(this ClaimsPrincipal cp)
        where TClaims : class, new()
    {
        var result = new TClaims();
        var cusClaimsType = result.GetType();

        foreach (var claim in cp.Claims)
        {
            var pairKey = claim.Properties.Keys.FirstOrDefault();
            string? key;

            if (pairKey != null)
                claim.Properties.TryGetValue(pairKey, out key);
            else
                key = claim.Type;

            if (string.IsNullOrEmpty(key))
                continue;

            // 要符合Json轉換規範
            var CSharpWord = key.FirstAndBottomLineChartToUpper();

            var prop = cusClaimsType.GetProperty(CSharpWord);

            if (prop == null)
                continue;
            else
            {
                var typeCode = Type.GetTypeCode(prop.PropertyType);
                prop.SetValue(result, ConvertValue(typeCode, claim.Value));
            }
        }

        return result;
    }
}