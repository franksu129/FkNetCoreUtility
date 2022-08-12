namespace FkHelper;
public static class RandomHelper
{
    /// <summary>
    /// 排除 O、o、0、l、I、大寫
    /// </summary>
    private const string CharPattern01 = "abcdefghijkmnopqrstuvwxyz0123456789";

    /// <summary>
    /// 排除 O、o、0、l、I
    /// </summary>
    private const string CharPattern02 = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

    /// <summary>
    /// 依據長度和版型產生亂數字串
    /// </summary>
    public static string GetStringByCharPattern(string baseChar, int length)
    {
        var chars = new char[length];
        var rd = new Random();
        for (int i = 0; i < length; i++)
            chars[i] = baseChar[rd.Next(0, baseChar.Length)];

        return new string(chars);
    }

    /// <summary>
    /// 產生出一組亂數數字，其值 >= minValue，並且 < maxValue
    /// </summary>
    /// <param name="minValue">最小</param>
    /// <param name="maxValue">最大</param>
    public static int GetNumber(int minValue, int maxValue)
    {
        var random = new Random(Guid.NewGuid().GetHashCode());
        int result = random.Next(minValue, maxValue);
        return result;
    }

    public static string RandomLowerChar(int length)
        => GetStringByCharPattern(CharPattern01, length);

    public static string RandomChar(int length)
        => GetStringByCharPattern(CharPattern02, length);

}