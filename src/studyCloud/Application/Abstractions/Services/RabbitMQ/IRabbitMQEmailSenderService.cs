namespace Application.Abstractions.Services.RabbitMQ;

public interface IRabbitMQEmailSenderService
{
    void Send(ReadOnlyMemory<byte> message);
}