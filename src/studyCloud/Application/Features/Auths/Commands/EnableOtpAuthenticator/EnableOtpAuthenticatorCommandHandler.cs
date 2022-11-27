using Application.Abstractions.Services;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using MediatR;

namespace Application.Features.Auths.Commands.EnableOtpAuthenticator;

public class
        EnableOtpAuthenticatorCommandHandler : IRequestHandler<EnableOtpAuthenticatorCommandRequest,
            EnabledOtpAuthenticatorCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;
        private readonly AuthBusinessRules _authBusinessRules;

        public EnableOtpAuthenticatorCommandHandler(IUserService userService, IAuthService authService,
                                                    IOtpAuthenticatorRepository otpAuthenticatorRepository,
                                                    AuthBusinessRules authBusinessRules)
        {
            _userService = userService;
            _authService = authService;
            _otpAuthenticatorRepository = otpAuthenticatorRepository;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<EnabledOtpAuthenticatorCommandResponse> Handle(EnableOtpAuthenticatorCommandRequest request,
                                                             CancellationToken cancellationToken)
        {
            User user = await _userService.GetById(request.UserId);
            await _authBusinessRules.UserShouldBeExists(user);
            await _authBusinessRules.UserShouldNotBeHaveAuthenticator(user);

            OtpAuthenticator? isExistsOtpAuthenticator =
                await _otpAuthenticatorRepository.GetAsync(o => o.UserId == request.UserId);
            await _authBusinessRules.OtpAuthenticatorThatVerifiedShouldNotBeExists(isExistsOtpAuthenticator);
            if (isExistsOtpAuthenticator is not null)
                await _otpAuthenticatorRepository.DeleteAsync(isExistsOtpAuthenticator);

            OtpAuthenticator newOtpAuthenticator = await _authService.CreateOtpAuthenticator(user);
            OtpAuthenticator addedOtpAuthenticator =
                await _otpAuthenticatorRepository.AddAsync(newOtpAuthenticator);

            EnabledOtpAuthenticatorCommandResponse enabledOtpAuthenticatorDto = new()
            {
                SecretKey = await _authService.ConvertSecretKeyToString(addedOtpAuthenticator.SecretKey)
            };
            return enabledOtpAuthenticatorDto;
        }
    }