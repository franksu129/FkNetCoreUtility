namespace FkNetCoreUtility.FkAwsS3.Models;

public struct AwsS3Settings
{
    public string Region { get; set; }
    public string BucketName { get; set; }
    public string AccessKeyId { get; set; }
    public string SecretAccessKey { get; set; }
}