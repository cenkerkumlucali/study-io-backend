using Application.Abstractions.Services.Paging;
using Application.Features.Users.UserCoin.Models;
using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.UserCoin.Queries.GetListUserCoin;

public class GetListUserCoinQueryHandler : IRequestHandler<GetListUserCoinQueryRequest, UserCoinListModel>
{
    private readonly IUserCoinRepository _userCoinRepository;
    private IMapper _mapper;

    public GetListUserCoinQueryHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
    {
        _userCoinRepository = userCoinRepository;
        _mapper = mapper;
    }

    public async Task<UserCoinListModel> Handle(GetListUserCoinQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Users.UserCoin> userCoin =
            await _userCoinRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include:c=>c.Include(c=>c.User));
        UserCoinListModel mappedUserCoinListModel =
            _mapper.Map<UserCoinListModel>(userCoin);
        return mappedUserCoinListModel;
    }
}