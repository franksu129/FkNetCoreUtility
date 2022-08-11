using FkMail.Models;

namespace FkMail;

public interface IMail
{
    /// <summary>
    /// 寄送Email
    /// </summary>
    /// <param name="recipient">收件只Email</param>
    /// <param name="subject">信件主旨</param>
    /// <param name="content">信件內容</param>
    /// <param name="recipientName">收件者名稱</param>
    public void SendMail(string recipient, string subject, string content, string recipientName = "");

    public void SendMail(string recipient, string subject, string content, List<AttachmentFile> AttachmentFile, string recipientName = "");
}
