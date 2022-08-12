using System.Text.RegularExpressions;

namespace FkHelper;
public static class RegexHelper
{
    private static bool TestPattern(string str, string pattern)
        => new Regex(pattern, RegexOptions.Compiled).IsMatch(str);

    public static bool IsValidatedMail(string email)
        => TestPattern(email, @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");

    public static bool IsValidatedAccount(string account)
        => TestPattern(account, @"^[\w_-]{3,15}$");

    public static bool IsValidatedSymbol(string str)
    {
        if (str.Contains(" "))
            return false;

        return TestPattern(str, @"^\s|\\\\|\+|\@|\`|\!|\~|\#|\$|\%|\^|\&|\*|\=|\[|\]|\{|\}|\:|\;|\\\'|\"" |\,|\.|\?|\/|\<|\>|\，|\。|\、|\【|\】|\《|\》|\〈|\〉|\「|\」|\『|\』|\；|\：|\’|\＂|\｛|\｝|\［|\］|\（|\）|\！|\＠|\＃|\＄|\％|\︿|\＆|\＊|\＋|\－|\＼|\＝|\？|\/|\～|\‵$");
    }

}