using Application.Repositories.Services.Users;
using AutoMapper;
using Domain.Entities.ImageFile;
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
        UserImageFile userImage = _mapper.Map<UserImageFile>(request);
        UserImageFile createdUserImage =
            await _userImageRepository.UpdateAsync(userImage);
        UpdateUserImageCommandResponse updatedUserImageDto =
            _mapper.Map<UpdateUserImageCommandResponse>(createdUserImage);
        return updatedUserImageDto;
    }
}