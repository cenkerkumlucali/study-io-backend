using System.Net.Mail;

namespace RabbitMQ.EmailSender.Services;

public class MailMessageData
{
    public int RoutingKey { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? VerifyEmailUrlPrefix { get; set; }
    public string? ActivationKey { get; set; }
    
}