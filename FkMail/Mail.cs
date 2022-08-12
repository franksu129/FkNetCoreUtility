using FkMail;
using FkMail.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace FkMail;

public class Mail : IMail
{
    private readonly MailSettings settings;

    public Mail(MailSettings settings)
    {
        this.settings = settings;
    }

    private MimeEntity GetMessageBody(string content, List<AttachmentFile> AttachmentFile)
    {
        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = content;

        if (AttachmentFile != null && AttachmentFile.Any())
        {
            foreach (var atta in AttachmentFile)
            {
                byte[] bt = File.ReadAllBytes(atta.LocalFilePath);
                bodyBuilder.Attachments.Add(atta.Name, bt);
            }
        }

        return bodyBuilder.ToMessageBody();
    }

    private void rootSendMail(MimeMessage message)
    {
        using var client = new SmtpClient();
        client.Connect(settings.Host, settings.Port, false);
        client.Authenticate(settings.Account, settings.Password);
        client.Send(message);
        client.Disconnect(true);
    }

    public void SendMail(string recipient, string subject, string content, string recipientName = "")
        => SendMail(recipient, subject, content, new List<AttachmentFile>(), recipientName);

    public void SendMail(string recipient, string subject, string content, List<AttachmentFile> AttachmentFile, string recipientName = "")
    {
        var message = new MimeMessage();
        var from = new MailboxAddress(settings.MailFromName, settings.MailFromAddress);
        var name = string.IsNullOrEmpty(recipientName) ? recipient : recipientName;
        var to = new MailboxAddress(name, recipient);

        message.From.Add(from);
        message.To.Add(to);
        message.Subject = subject;
        message.Body = GetMessageBody(content, AttachmentFile);

        rootSendMail(message);
    }
}