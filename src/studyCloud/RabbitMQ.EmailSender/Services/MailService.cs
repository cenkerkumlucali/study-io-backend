using System.Net;
using System.Net.Mail;
using System.Text;

namespace RabbitMQ.EmailSender.Services;

public class MailService : IMailService
{
    private readonly IConfiguration _configuration;

    public MailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
    {
        await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
    }

    public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
    {
        try
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                foreach (string to in tos) mailMessage.To.Add(to);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.From = new MailAddress(_configuration["Mail:Username"], "Study.Io",
                    System.Text.Encoding.UTF8);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isBodyHtml;

                using (SmtpClient smtp = new SmtpClient(_configuration["Mail:Host"],
                           Convert.ToInt32(_configuration["Mail:Port"])))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials =
                        new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mailMessage);
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    public async Task SendPasswordResetMailAsync(string to,string fullName,string authenticatorCode)
    {
        string mail =
        $"Merhaba <strong>{fullName}</strong><br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki kod ile şifrenizi yenileyebilirsiniz.<br><strong>{authenticatorCode}</strong><br><br><span style=\"font-size:12px;\">NOT : Eğer ki bu talep tarafınızca gerçekleştirilmemişse lütfen bu maili ciddiye almayınız.</span><br>Saygılarımızla...<br><br><br>Study.Io"; 
        await SendMailAsync(to, "Şifre Yenileme Talebi", mail);
    }

    public async Task SendEnableEmailAuthenticatorAsync(string to, string firstName,string lastName,string verifyEmailUrlPrefix,string activationKey)
    {
        string mail = $"{firstName} {lastName} <br>" +
                      $"Click on the link to verify your email: {verifyEmailUrlPrefix}?ActivationKey={activationKey})";
        await SendMailAsync(to, $"Verify Your Email - Study.io", mail);
    }

    public async Task SendAuthenticatorCodeAsync(string to, string firstName, string lastName, string authenticatorCode)
    {
        string mail = $"{firstName} {lastName} <br>" +
                      $"Enter your authenticator code: {authenticatorCode}";
        await SendMailAsync(to, $"Authenticator Code - Study.io", mail);
    }
}
