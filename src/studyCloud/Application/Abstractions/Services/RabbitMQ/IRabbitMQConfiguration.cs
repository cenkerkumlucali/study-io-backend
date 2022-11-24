namespace Application.Abstractions.Services.RabbitMQ;

public class IRabbitMQConfiguration
{
    public string HostName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}