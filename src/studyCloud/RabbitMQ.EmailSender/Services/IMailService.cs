namespace RabbitMQ.EmailSender.Services;

public interface IMailService
{
    Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);
    Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
    Task SendPasswordResetMailAsync(string to);
    Task SendCompletedOrderMailAsync(string to, string userName, string orderCode, DateTime orderDate);
}