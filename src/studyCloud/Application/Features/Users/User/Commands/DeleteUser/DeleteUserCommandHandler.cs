using Application.Abstractions.Services.ElasticSearch;
using Application.DTOs.ElasticSearch;
using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Rules;
using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IElasticSearch _elasticSearch;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _userBusinessRules;

    public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper,
        UserBusinessRules userBusinessRules, IElasticSearch elasticSearch)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userBusinessRules = userBusinessRules;
        _elasticSearch = elasticSearch;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        await _userBusinessRules.UserIdShouldExistWhenSelected(request.Id);

        Domain.Entities.Users.User mappedUser = _mapper.Map<Domain.Entities.Users.User>(request);
        Domain.Entities.Users.User deletedUser = await _userRepository.DeleteAsync(mappedUser);
        List<ElasticSearchGetModel<UserDto>> getUser = await
            _elasticSearch.GetSearchByField<UserDto>(
                new SearchByFieldParameters
                {
                    IndexName = "users",
                    FieldName = "UserName",
                    Value = deletedUser.UserName
                });
        ElasticSearchModel model = new()
        {
            ElasticId = getUser.FirstOrDefault()?.ElasticId,
            IndexName = "users",
        };
        await _elasticSearch.DeleteByElasticIdAsync(model);
        DeleteUserCommandResponse deletedUserDto = _mapper.Map<DeleteUserCommandResponse>(deletedUser);
        return deletedUserDto;
    }
}