using FkNetCoreUtility.FkAwsS3;
using FkNetCoreUtility.FkAwsS3.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FkUtilityTests.FkAwsS3Test;

[TestClass]
public class AwsS3Test
{
    [TestMethod]
    [DeploymentItem(@"FkAwsS3Test\AwsTestFile.txt", "TestStaticFile")]
    public void UploadToS3MemoryTest()
    {
        IAwsS3 jwtHelper = new AwsS3(new AwsS3Settings
        {
            AccessKeyId = "",
            SecretAccessKey = "",
            // RootName
            BucketName = "franks3bucket",
            Region = "ap-northeast-1"
        });

        var filePath = @"TestStaticFile\AwsTestFile.txt";
        var MyFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        using var MemoryStream = new MemoryStream();
        MyFileStream.CopyTo(MemoryStream);
        var fileUrl = jwtHelper.UploadToS3("FkUtilityTests", MemoryStream, "txt", UrlType.S3);

        // AWS　還需要針對權限下去測試
        // var fileUrl = jwtHelper.UploadToS3("image/AvatarCustomer", MemoryStream, "txt", UrlType.S3);

        Assert.IsNotNull(fileUrl);
    }

    [TestMethod]
    [DeploymentItem(@"FkAwsS3Test\AwsTestFile.txt", "TestStaticFile")]
    public void UploadToS3ByteTest()
    {
        IAwsS3 jwtHelper = new AwsS3(new AwsS3Settings
        {
            AccessKeyId = "",
            SecretAccessKey = "",
             // RootName
            BucketName = "franks3bucket",
            Region = "ap-northeast-1"
        });

        var filePath = @"TestStaticFile\AwsTestFile.txt";
        var myBytes = File.ReadAllBytes(filePath);
        var fileUrl = jwtHelper.UploadToS3("FkUtilityTests", myBytes, "txt", UrlType.S3);

        Assert.IsNotNull(fileUrl);
    }
}