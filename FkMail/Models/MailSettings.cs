public struct MailSettings
{
    /// <summary>
    /// 寄件者名稱
    /// </summary>
    public string MailFromName { get; set; }

    /// <summary>
    /// 寄件者信箱
    /// </summary>
    public string MailFromAddress { get; set; }

    /// <summary>
    /// 寄件伺服器主機位置
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// 寄件伺服器使用Port
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// 寄件伺服器帳號
    /// </summary>
    public string Account { get; set; }

    /// <summary>
    /// 寄件伺服器密碼
    /// </summary>
    public string Password { get; set; }
}