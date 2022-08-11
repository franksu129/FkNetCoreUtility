namespace FkMail.Models;

public class AttachmentFile
{
    /// <summary>
    /// 檔案名稱
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// 檔案路徑
    /// </summary>
    public string LocalFilePath { get; set; } = "";
}