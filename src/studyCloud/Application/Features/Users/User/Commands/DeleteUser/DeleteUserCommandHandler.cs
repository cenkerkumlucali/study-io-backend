using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Rules;
using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper,
        UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

        Domain.Entities.Users.User mappedUser = _mapper.Map<Domain.Entities.Users.User>(request);
        Domain.Entities.Users.User deletedUser = await _userRepository.DeleteAsync(mappedUser);
        DeleteUserCommandResponse deletedUserDto = _mapper.Map<DeleteUserCommandResponse>(deletedUser);
        return deletedUserDto;
    }
}