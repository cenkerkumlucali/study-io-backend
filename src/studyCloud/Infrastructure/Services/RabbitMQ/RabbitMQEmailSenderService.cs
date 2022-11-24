using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using Application.Abstractions.Services.RabbitMQ;
using Application.DTOs.RabbitMQ;

namespace Infrastructure.Services.RabbitMQ;

public class RabbitMQEmailSenderService: IRabbitMQEmailSenderService, IDisposable
{
    private readonly RabbitMQHelper _rabbitMqHelperService;
    private readonly IConfiguration _configuration;

    private IModel _channel;
    private IConnection _connection;
    private readonly object _locker = new object();

    private const string ConfigKey = "RabbitMq:EmailSender:";
   public RabbitMQEmailSenderService(RabbitMQHelper rabbitMqHelperService,
            IConfiguration configuration)
        {
            _rabbitMqHelperService = rabbitMqHelperService;
            _configuration = configuration;

            //var factory = _rabbitMqHelperService.GetConnectionFactory();

            //_connection = factory.CreateConnection();
            //_channel = _connection.CreateModel();

            //_channel.ExchangeDeclare(exchange: _configuration[ConfigKey + "exchangeName"], type: ExchangeType);
        }

        private IModel GetChannel()
        {
            if (_channel is null) OpenChannel();

            return _channel;
        }

        private void OpenChannel()
        {
            var factory = new ConnectionFactory();

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();

            var queueName = _configuration[ConfigKey + "queue"];

            BindRoutingKeysToQueue(
                _channel,
                queueName,
                _configuration[ConfigKey + "exchangeName"],
                new[]
                {
                    MessageRoutingKey.SubscribeNotification
                });
        }

        private void BindRoutingKeysToQueue(IModel channelForBinding, string queueName, string exchangeName,
            string[] routingKeys)
        {
            foreach (var routingKey in routingKeys)
                channelForBinding.QueueBind(queueName, exchangeName, routingKey, null);
        }

        public void Send(ReadOnlyMemory<byte> message)
        {
            lock (_locker)
            {
                GetChannel().BasicPublish(_configuration[ConfigKey + "exchangeName"], MessageRoutingKey.SubscribeNotification, true, body: message.ToArray());
            }
        }


        //public void Send(ReadOnlyMemory<byte> message)
        //{
        //    lock (_locker)
        //    {
        //        _channel.BasicPublish(exchange: _configuration[ConfigKey + "exchangeName"],
        //                              routingKey: _configuration[ConfigKey + "routingKey"],
        //                              basicProperties: null,
        //                              body: message.ToArray());
        //    }
        //}

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }

}