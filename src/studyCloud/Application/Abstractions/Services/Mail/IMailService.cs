namespace Application.Abstractions.Services.Mail;

public interface IMailService
{
    void SendMail(DTOs.Mail.Mail mail);
}