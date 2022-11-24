using Application.Repositories.Services.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserImage.Commands.UpdateUserImage;

public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommandRequest, UpdateUserImageCommandResponse>
{
    private readonly IUserImageRepository _userImageRepository;
    private IMapper _mapper;

    public UpdateUserImageCommandHandler(IUserImageRepository userImageRepository, IMapper mapper)
    {
        _userImageRepository = userImageRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserImageCommandResponse> Handle(UpdateUserImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.UserImageFile userImage = _mapper.Map<Domain.Entities.Users.UserImageFile>(request);
        Domain.Entities.Users.UserImageFile createdUserImage =
            await _userImageRepository.UpdateAsync(userImage);
        UpdateUserImageCommandResponse updatedUserImageDto =
            _mapper.Map<UpdateUserImageCommandResponse>(createdUserImage);
        return updatedUserImageDto;
    }
}