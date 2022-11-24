using Application.Abstractions.Services.RabbitMQ;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services.RabbitMQ;

public class RabbitMQConfiguration:IRabbitMQConfiguration
{
    public IConfiguration Configuration { get; set; }
    public string HostName => Configuration.GetSection("RabbitMQConfiguration:HostName").Value;
    public string UserName => Configuration.GetSection("RabbitMQConfiguration:UserName").Value;
    public string Password => Configuration.GetSection("RabbitMQConfiguration:Password").Value;
}