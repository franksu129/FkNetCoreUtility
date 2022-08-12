
using FkHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FkUtilityTests.FkHelper;

[TestClass]
public class HashHelperTest
{
    [TestMethod]
    public void HMACSHA256Test()
    {
        string str = "abc123";
        var hsCode = HashHelper.HashSHA256(str);

        Assert.IsNotNull(hsCode);
        Assert.IsTrue(hsCode != "");
    }

    [TestMethod]
    public void HashSHA256Test()
    {
        string str = "abc123";
        var hsCode = HashHelper.HashSHA256(str);

        Assert.IsNotNull(hsCode);
        Assert.IsTrue(hsCode != "");
    }

    [TestMethod]
    public void HashMD5Test()
    {
        string str = "abc123";
        var hsCode = HashHelper.HashMD5(str);

        Assert.IsNotNull(hsCode);
        Assert.IsTrue(hsCode != "");
    }
}