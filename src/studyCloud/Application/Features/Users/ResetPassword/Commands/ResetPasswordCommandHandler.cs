using System.Text;
using Application.Abstractions.Services.RabbitMQ;
using Application.Features.Users.ResetPassword.Constants;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Features.Users.ResetPassword.Commands;

public class ResetPasswordCommandHandler:IRequestHandler<ResetPasswordCommandRequest>
{
    private readonly ILogger<ResetPasswordCommandHandler> _logger;
    private readonly IRabbitMQEmailSenderService _rabbitMQEmailSenderService;

    public ResetPasswordCommandHandler(IRabbitMQEmailSenderService rabbitMqEmailSenderService, ILogger<ResetPasswordCommandHandler> logger)
    {
        _rabbitMQEmailSenderService = rabbitMqEmailSenderService;
        _logger = logger;
    }

    public async Task<Unit> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Send notifications through RabbitMQ");

         _rabbitMQEmailSenderService.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request)));
        return Unit.Value;
    }
}