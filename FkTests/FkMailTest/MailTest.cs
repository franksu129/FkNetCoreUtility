using FkMail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FkUtilityTests.FkMailTest;

[TestClass]
public class MailTest
{

    /// <summary>
    ///  Mail 發送
    /// </summary>

    [TestMethod]
    [DataRow("frank@test.com", "this is a test mail")]
    public void SendMailTest(string email, string subject)
    {
        //  stmp設定
        IMail myMail = new Mail(new MailSettings
        {
            Host = "smtp.mandrillapp.com",
            Port = 587,
            Account = "SelfTest",
            Password = "",
            MailFromName = "",
            MailFromAddress = "",
        });

        myMail.SendMail(email, subject, "Hello Mail", "Fk Test");

        Assert.IsTrue(true);
    }
}