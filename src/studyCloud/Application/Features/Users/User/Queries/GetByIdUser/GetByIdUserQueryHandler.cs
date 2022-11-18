using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Rules;
using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Queries.GetByIdUser;

public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper,
        UserBusinessRules userBusinessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
    }


    public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

        Domain.Entities.Users.User? user = await _userRepository.GetAsync(b => b.Id == request.Id);
        GetByIdUserQueryResponse userDto = _mapper.Map<GetByIdUserQueryResponse>(user);
        return userDto;
    }
}