using System.Net.Sockets;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace RabbitMQ.EmailSender.Services;

public class RabbitMQPersistentConnection : IDisposable
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly int _retryCount;
    private IConnection _connection;
    private object lock_object = new object();
    private bool _disposed;

    public RabbitMQPersistentConnection(IConnectionFactory connectionFactory, int retryCount = 5)
    {
        _connectionFactory = connectionFactory;
        _retryCount = retryCount;
    }

    public bool IsConnected => _connection != null && _connection.IsOpen;

    public IModel CreateModel()
    {
        return _connection.CreateModel();
    }

    public void Dispose()
    {
        _disposed = true;
        _connection.Dispose();
    }

    public bool TryConnect()
    {
        lock (lock_object)
        {
            var policy = Policy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (ex, time) => { });
            policy.Execute(() => { _connection = _connectionFactory.CreateConnection(); });
            if (IsConnected)
            {
                _connection.ConnectionShutdown += ConnectionConnectionShutdown;
                _connection.CallbackException += ConnectionOnCallbackException;
                _connection.ConnectionBlocked += ConnectionOnConnectionBlocked;
                return true;
            }

            return false;
        }
    }

    private void ConnectionOnConnectionBlocked(object? sender, ConnectionBlockedEventArgs e)
    {
        if (_disposed) return;
        TryConnect();
    }

    private void ConnectionOnCallbackException(object? sender, CallbackExceptionEventArgs e)
    {
        if (_disposed) return;
        TryConnect();
    }

    private void ConnectionConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        if (_disposed) return;
        TryConnect();
    }
}