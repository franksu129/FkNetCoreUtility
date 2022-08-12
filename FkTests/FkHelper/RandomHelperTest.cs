using FkHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FkUtilityTests.FkHelper;

[TestClass]
public class RandomHelperTest
{
    [TestMethod]
    public void GetNumberTest()
    {
        var number = RandomHelper.GetNumber(1, 2);

        Assert.IsTrue((number >= 1) && (number < 10));
    }

    [TestMethod]
    public void GetStringByCharPatternTest()
    {
        var pattern = "1234";
        var str = RandomHelper.GetStringByCharPattern(pattern, 2);

        Assert.IsTrue(int.TryParse(str, out _));
    }
}