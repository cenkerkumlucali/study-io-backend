using System.Text;
using System.Text.Json;
using Application.Abstractions.Services.RabbitMQ;
// using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace RabbitMQ.EmailSender.Services;

public class ConsumerManager : IConsumerService
    {
        private SemaphoreSlim _semaphore;
        private EventingBasicConsumer _consumer;
        private IModel _channel;
        private IConnection _connection;

        private readonly IRabbitMQService _rabbitMQServices;
        private readonly IObjectConvertFormat _objectConvertFormat;
        private readonly IMailService _mailSender;

        public ConsumerManager(
            IRabbitMQService rabbitMQServices,
            IMailService mailSender,
            IObjectConvertFormat objectConvertFormat
            )
        {
            _rabbitMQServices = rabbitMQServices;
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(mailSender));
            _objectConvertFormat = objectConvertFormat;
        }

        public async Task Start()
        {
            try
            {
                _semaphore = new SemaphoreSlim(RabbitMQConsts.ParallelThreadsCount);
                _connection = _rabbitMQServices.GetConnection();
                _channel = _rabbitMQServices.GetModel(_connection);
                _channel.QueueDeclare(queue: RabbitMQConsts.RabbitMqConstsList.EmailSender.ToString(),
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                _channel.BasicQos(0, RabbitMQConsts.ParallelThreadsCount, false);
                _consumer = new EventingBasicConsumer(_channel);
                _consumer.Received += Consumer_Received;
                await Task.FromResult(_channel.BasicConsume(queue: RabbitMQConsts.RabbitMqConstsList.EmailSender.ToString(),
                                           autoAck: false,  
                                           /* autoAck: bir mesajı aldıktan sonra bunu anladığına       
                                              dair(acknowledgment) kuyruğa bildirimde bulunur ya da timeout gibi vakalar oluştuğunda 
                                              mesajı geri çevirmek(Discard) veya yeniden kuyruğa aldırmak(Re-Queue) için dönüşler yapar*/
                                           consumer: _consumer));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message.ToString());
            }
        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs ea)
        {
            try
            {
                
                
                _semaphore.Wait();
                var message = _objectConvertFormat.JsonToObject<object>(Encoding.UTF8.GetString(ea.Body.Span));
                // MessageReceived?.Invoke(this, message);
                // E-Posta akışını başlatma yeri
                Task.Run(async () =>
                {
                    try
                    {
                        MailMessageData? mailMessageData = JsonSerializer.Deserialize<MailMessageData>(Encoding.UTF8.GetString(ea.Body.Span));
                        // var task =
                        switch (mailMessageData.RoutingKey)
                        {
                            case 0:
                                await _mailSender.SendPasswordResetMailAsync(mailMessageData.Email);
                                break;
                            case 1:
                                await _mailSender.SendEnableEmailAuthenticatorAsync(mailMessageData.Email,mailMessageData.FirstName,mailMessageData.LastName,mailMessageData.VerifyEmailUrlPrefix,mailMessageData.ActivationKey);
                                break;
                            case 2:
                                await _mailSender.SendAuthenticatorCodeAsync(mailMessageData.Email, mailMessageData.FirstName,
                                    mailMessageData.LastName, mailMessageData.ActivationKey);
                                break;
                        }
                        // task.Wait();
                        // var result = task.;
                        // MessageProcessed?.Invoke(this);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                    finally
                    {
                        // Teslimat Onayı
                        _channel.BasicAck(ea.DeliveryTag, false);
                        // akışı - thread'i serbest bırakıyoruz ek thread alabiliriz.
                        _semaphore.Release();
                    }
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message.ToString());
            }
        }



        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            _channel.Dispose();
            //_connection.Dispose();
            _semaphore.Dispose();
        }


    }