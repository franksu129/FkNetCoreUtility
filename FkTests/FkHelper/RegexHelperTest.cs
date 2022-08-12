using FkHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FkUtilityTests.FkHelper;

[TestClass]
public class RegexHelperTest
{
    [TestMethod]
    [DataRow("test", false)]
    [DataRow("test@gmail.com",true)]
    public void IsValidatedMailTest(string email,bool result)
    {
        Assert.AreEqual(result, RegexHelper.IsValidatedMail(email));
    }

    [TestMethod]
    [DataRow("12", false)]
    [DataRow("abc123xyz", true)]
    public void IsValidatedAccountTest(string account, bool result)
    {
        Assert.AreEqual(result, RegexHelper.IsValidatedAccount(account));
    }

    [TestMethod]
    [DataRow("@#$%^&*", true)]
    [DataRow("abc123xyz", false)]
    public void IsValidatedSymbolTest(string str, bool result)
    {
        Assert.AreEqual(result, RegexHelper.IsValidatedSymbol(str));
    }
}