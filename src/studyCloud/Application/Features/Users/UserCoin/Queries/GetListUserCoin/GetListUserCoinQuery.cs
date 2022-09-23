using Application.Features.Users.UserCoin.Models;
using Application.Services.Repositories.Quizzes;
using Application.Services.Repositories.Users;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Users.UserCoin.Queries.GetListUserCoin;

public class GetListUserCoinQuery : IRequest<UserCoinListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserCoinQueryHandler : IRequestHandler<GetListUserCoinQuery, UserCoinListModel>
    {
        private readonly IUserCoinRepository _userCoinRepository;
        private IMapper _mapper;

        public GetListUserCoinQueryHandler(IUserCoinRepository userCoinRepository, IMapper mapper)
        {
            _userCoinRepository = userCoinRepository;
            _mapper = mapper;
        }

        public async Task<UserCoinListModel> Handle(GetListUserCoinQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Users.UserCoin> userCoin =
                await _userCoinRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            UserCoinListModel mappedUserCoinListModel =
                _mapper.Map<UserCoinListModel>(userCoin);
            return mappedUserCoinListModel;
        }
    }
}