using Application.Abstractions.Services.Paging;
using Application.Features.Users.User.Models;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Queries.GetListUser;

public class GetListUserQueryHandler : IRequestHandler<GetListUserQueryRequest, UserListModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserListModel> Handle(GetListUserQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Users.User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);
        return mappedUserListModel;
    }
}