using System.Collections;

namespace Application.Abstractions.Services.RabbitMQ;

public interface IPublisherService
{
    void Enqueue(object queueDataModels, string queueName );
}