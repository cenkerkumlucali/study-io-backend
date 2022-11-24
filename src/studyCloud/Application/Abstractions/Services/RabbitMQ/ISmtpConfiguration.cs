namespace Application.Abstractions.Services.RabbitMQ;

public interface ISmtpConfiguration
{
    string Host { get; }
    int Port { get; }
    string User { get; }
    string Password { get; }
    bool UseSSL { get; }
    SmtpConfig GetSmtpConfig();
}