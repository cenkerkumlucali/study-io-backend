using System.Net.Mail;

namespace RabbitMQ.EmailSender.Services;

public class MailMessageData
{
    public string To { get; set; }

    public MailMessage GetMailMessage()
    {
        var mailMessage = new MailMessage
        {
            Subject = "",
            Body = "this.Body",
            From = new MailAddress("this.From")
        };
        mailMessage.To.Add(To);
        return mailMessage;
    }
}