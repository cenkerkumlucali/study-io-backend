using Application.Features.Users.UserImage.Dtos;
using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserImage.Queries.GetByIdUserCoin;

public class GetByIdUserImageQuery : IRequest<GetByIdUserImageDto>
{
    public int Id { get; set; }
    public class GetByIdUserImageQueryHandler : IRequestHandler<GetByIdUserImageQuery, GetByIdUserImageDto>
    {
        private readonly IUserImageRepository _userImageRepository;
        private IMapper _mapper;

        public GetByIdUserImageQueryHandler(IUserImageRepository userImageRepository, IMapper mapper)
        {
            _userImageRepository = userImageRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserImageDto> Handle(GetByIdUserImageQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserImageFile? userImage =
                await _userImageRepository.GetAsync(c => c.Id == request.Id);
            GetByIdUserImageDto getByIdUserImageDto =
                _mapper.Map<GetByIdUserImageDto>(userImage);
            return getByIdUserImageDto;
        }
    }
}