using System.Text;
using System.Web;
using Application.Abstractions.Services;
using Application.Abstractions.Services.Mail;
using Application.Abstractions.Services.RabbitMQ;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Auths.Commands.EnableEmailAuthenticator;

public class EnableEmailAuthenticatorCommandHandler : IRequestHandler<EnableEmailAuthenticatorCommandRequest>
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
    private readonly IMailService _mailService;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly IRabbitMQEmailSenderService _rabbitMQEmailSenderService;

    public EnableEmailAuthenticatorCommandHandler(IUserService userService, IAuthService authService,
        IEmailAuthenticatorRepository emailAuthenticatorRepository, IMailService mailService,
        AuthBusinessRules authBusinessRules, IRabbitMQEmailSenderService rabbitMqEmailSenderService)
    {
        _userService = userService;
        _authService = authService;
        _emailAuthenticatorRepository = emailAuthenticatorRepository;
        _mailService = mailService;
        _authBusinessRules = authBusinessRules;
        _rabbitMQEmailSenderService = rabbitMqEmailSenderService;
    }

    public async Task<Unit> Handle(EnableEmailAuthenticatorCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userService.GetById(request.UserId);
        await _authBusinessRules.UserShouldBeExists(user);
        await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);
        await _authService.DeleteOldEmailAuthenticators(user);
        EmailAuthenticator emailAuthenticator = await _authService.CreateEmailAuthenticator(user);
        EmailAuthenticator addedEmailAuthenticator =
            await _emailAuthenticatorRepository.AddAsync(emailAuthenticator);

        EmailAuthenticatorDto emailAuthenticatorDto = new EmailAuthenticatorDto()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            VerifyEmailUrlPrefix = request.VerifyEmailUrlPrefix,
            ActivationKey = HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey),
            RoutingKey = request.RoutingKey
        };
        
        _rabbitMQEmailSenderService.Send(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(emailAuthenticatorDto)));

        // _mailService.SendMail(new Mail
        // {
        //     ToEmail = user.Email,
        //     ToFullName = $"{user.FirstName} ${user.LastName}",
        //     Subject = "Verify Your Email - RentACar",
        //     TextBody =
        //         $"Click on the link to verify your email: {request.VerifyEmailUrlPrefix}?ActivationKey={HttpUtility.UrlEncode(addedEmailAuthenticator.ActivationKey)}"
        // });

        return Unit.Value;
    }
}