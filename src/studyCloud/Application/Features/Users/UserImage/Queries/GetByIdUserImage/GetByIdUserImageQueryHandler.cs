using Application.Repositories.Services.Users;
using AutoMapper;
using Domain.Entities.ImageFile;
using MediatR;

namespace Application.Features.Users.UserImage.Queries.GetByIdUserImage;

public class GetByIdUserImageQueryHandler : IRequestHandler<GetByIdUserImageQueryRequest, GetByIdUserImageQueryResponse>
{
    private readonly IUserImageRepository _userImageRepository;
    private IMapper _mapper;

    public GetByIdUserImageQueryHandler(IUserImageRepository userImageRepository, IMapper mapper)
    {
        _userImageRepository = userImageRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdUserImageQueryResponse> Handle(GetByIdUserImageQueryRequest request, CancellationToken cancellationToken)
    {
        UserImageFile? userImage =
            await _userImageRepository.GetAsync(c => c.Id == request.Id);
        GetByIdUserImageQueryResponse getByIdUserImageDto =
            _mapper.Map<GetByIdUserImageQueryResponse>(userImage);
        return getByIdUserImageDto;
    }
}