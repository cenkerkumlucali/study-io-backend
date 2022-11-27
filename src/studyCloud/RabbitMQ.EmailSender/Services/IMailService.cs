namespace RabbitMQ.EmailSender.Services;

public interface IMailService
{
    Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);
    Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
    Task SendPasswordResetMailAsync(string to);
    Task SendEnableEmailAuthenticatorAsync(string to, string firstName,string lastName,string verifyEmailUrlPrefix,string activationKey);
    Task SendAuthenticatorCodeAsync(string to, string firstName,string lastName,string authenticatorCode);
}