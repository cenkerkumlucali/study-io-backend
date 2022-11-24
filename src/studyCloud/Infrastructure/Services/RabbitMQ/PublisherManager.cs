using System.Text;
using Application.Abstractions.Services.RabbitMQ;
using RabbitMQ.Client;

namespace Infrastructure.Services.RabbitMQ;

public class PublisherManager : IPublisherService
{
    private readonly IRabbitMQService _rabbitMQServices;
    private readonly IObjectConvertFormat _objectConvertFormat;
    private dynamic _channel;
    private dynamic _connection;

    public PublisherManager(IRabbitMQService rabbitMQServices, IObjectConvertFormat objectConvertFormat)
    {
        _rabbitMQServices = rabbitMQServices;
        _objectConvertFormat = objectConvertFormat;
    }

    public void Enqueue(object queueDataModels, string queueName)
    {
        try
        {
            var factory = new ConnectionFactory();
            _connection = _rabbitMQServices.GetConnection();
            using (_channel = factory.CreateConnection())
            {
                _channel.QueueDeclare(queue: queueName,
                durable: true, // ile in-memory mi yoksa fiziksel olarak mı saklanacağı belirlenir.
                exclusive: false, // yalnızca bir bağlantı tarafından kullanılır ve bu bağlantı kapandığında sıra silinir - özel olarak işaretlenirse silinmez
                autoDelete: false, // en son bir abonelik iptal edildiğinde en az bir müşteriye sahip olan kuyruk silinir
                arguments: null); // isteğe bağlı; eklentiler tarafından kullanılır ve TTL mesajı, kuyruk uzunluğu sınırı, vb. 
                _channel.ExchangeDeclare(exchange: "CKEventBus", type: "direct");

                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.Expiration = RabbitMQConsts.MessagesTTL.ToString();


                var body = Encoding.UTF8.GetBytes(_objectConvertFormat.ObjectToJson(queueDataModels));
                _channel.BasicPublish(exchange: "",
                    routingKey: queueName,
                    mandatory: false,
                    basicProperties:  properties,
                    body: body);
            }
        }
        catch (Exception ex)
        {
            //loglama yapılabilir
            throw new Exception(ex.InnerException.Message.ToString());
        }
    }
}