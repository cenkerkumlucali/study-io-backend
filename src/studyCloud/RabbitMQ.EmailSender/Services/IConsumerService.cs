namespace RabbitMQ.EmailSender.Services;

public interface IConsumerService:IDisposable
{
    Task Start();
    void Stop();
}