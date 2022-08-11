using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using FkNetCoreUtility.FkAwsS3.Models;

namespace FkNetCoreUtility.FkAwsS3;

public class AwsS3 : IAwsS3
{
    public readonly AwsS3Settings settings;

    /// <summary>
    /// S3地區
    /// </summary>
    private RegionEndpoint bucketRegion => RegionEndpoint.GetBySystemName(settings.Region);

    public AwsS3(AwsS3Settings Settings)
    {
        this.settings = Settings;
    }

    /// <summary>
    /// 上傳檔案至S3 (byte[])
    /// </summary>
    public string UploadToS3(string Folder, byte[] source, string FileExtension, UrlType ReturnUrlType = UrlType.Default)
    {
        using var myDataStream = new MemoryStream(source);
        return UploadToS3(Folder, myDataStream, FileExtension, ReturnUrlType);
    }

    /// <summary>
    /// 上傳檔案至S3 (Stream)
    /// </summary>
    public string UploadToS3(string Folder, MemoryStream DataStream, string FileExtension, UrlType ReturnUrlType = UrlType.Default)
    {
        var folderPath = $"{settings.BucketName}/{Folder}";
        var fileName = $"{Guid.NewGuid()}.{FileExtension}";

        try
        {
            using var client = new AmazonS3Client(settings.AccessKeyId, settings.SecretAccessKey, bucketRegion);
            var fileTransferUtility = new TransferUtility(client);

            var request = new TransferUtilityUploadRequest()
            {
                BucketName = folderPath,
                Key = fileName,
                InputStream = DataStream,
                CannedACL = S3CannedACL.PublicRead
            };

            fileTransferUtility.Upload(request);
        }
        catch
        {
            throw;
        }

        return ReturnUrlType switch
        {
            UrlType.S3 => $"https://{settings.BucketName}.s3.{bucketRegion.SystemName}.amazonaws.com/{Folder}/{fileName}",
            _ => $"https://{settings.BucketName}/{Folder}/{fileName}",
        };
    }
}