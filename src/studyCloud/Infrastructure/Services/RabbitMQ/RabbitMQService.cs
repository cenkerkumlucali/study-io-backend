using Application.Abstractions.Services.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;

namespace Infrastructure.Services.RabbitMQ;

public class RabbitMQService:IRabbitMQService
{
    private readonly IRabbitMQConfiguration _rabbitMQConfiguration;

    public RabbitMQService(IRabbitMQConfiguration rabbitMqConfiguration)
    {
        _rabbitMQConfiguration = rabbitMqConfiguration;
    }
    public  IConnection GetConnection()
    {
        try
        {
            var factory = new ConnectionFactory();
            // {
            //     HostName = _rabbitMQConfiguration.HostName,
            //     UserName = _rabbitMQConfiguration.UserName,
            //     Password = _rabbitMQConfiguration.Password
            // };

            // Otomatik bağlantı kurtarmayı etkinleştirmek için,
            factory.AutomaticRecoveryEnabled = true;
            // Her 10 sn de bir tekrar bağlantı toparlanmaya çalışır 
            factory.NetworkRecoveryInterval = TimeSpan.FromSeconds(10);
            // sunucudan bağlantısı kesildikten sonra kuyruktaki mesaj tüketimini sürdürmez 
            // (TopologyRecoveryEnabled = false   olarak tanımlandığı için)
            factory.TopologyRecoveryEnabled = false;

            return factory.CreateConnection();
        }
        catch (BrokerUnreachableException e)
        {
            // loglama işlemi yapabiliriz
            Thread.Sleep(5000);
            // farklı business ta yapılabilir, ancak biz tekrar bağlantı (connection) kurmayı deneyeceğiz
            return GetConnection();
        }
    }

    public IModel GetModel(IConnection connection)
    {
        return connection.CreateModel();
    }
}