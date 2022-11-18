using Application.Abstractions.Services.Paging;
using Application.Features.Users.UserImage.Models;
using Application.Repositories.Services.Users;
using Application.RequestParameters;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.UserImage.Queries.GetListUserCoin;

public class GetListUserImageQuery : IRequest<UserImageListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserImageQueryHandler : IRequestHandler<GetListUserImageQuery, UserImageListModel>
    {
        private readonly IUserImageRepository _userImageRepository;
        private IMapper _mapper;

        public GetListUserImageQueryHandler(IUserImageRepository userImageRepository, IMapper mapper)
        {
            _userImageRepository = userImageRepository;
            _mapper = mapper;
        }

        public async Task<UserImageListModel> Handle(GetListUserImageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Users.UserImageFile> userImage =
                await _userImageRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include:c=>c.Include(c=>c.Users));
            UserImageListModel mappedUserImageListModel =
                _mapper.Map<UserImageListModel>(userImage);
            return mappedUserImageListModel;
        }
    }
}