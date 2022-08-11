using FkNetCoreUtility.FkAwsS3.Models;

namespace FkNetCoreUtility.FkAwsS3;

public interface IAwsS3
{
    /// <summary>
    /// 上傳檔案至S3 (byte[])
    /// </summary>
    string UploadToS3(string Folder, byte[] source, string FileExtension, UrlType ReturnUrlType = UrlType.Default);

    /// <summary>
    /// 上傳檔案至S3 (Stream)
    /// </summary>
    string UploadToS3(string folder, MemoryStream Data, string fileExtension, UrlType returnUrlType = UrlType.Default);
}