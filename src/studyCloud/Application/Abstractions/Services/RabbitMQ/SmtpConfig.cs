namespace Application.Abstractions.Services.RabbitMQ;

public class SmtpConfig
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public bool UseSsl { get; set; }
}