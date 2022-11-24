using RabbitMQ.Client;

namespace Application.Abstractions.Services.RabbitMQ;

public interface IRabbitMQService
{
    IConnection GetConnection();
    IModel GetModel(IConnection connection);
}