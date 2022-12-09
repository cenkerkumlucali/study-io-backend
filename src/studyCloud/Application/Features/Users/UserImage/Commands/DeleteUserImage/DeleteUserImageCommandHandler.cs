using Application.Repositories.Services.Users;
using AutoMapper;
using Domain.Entities.ImageFile;
using MediatR;

namespace Application.Features.Users.UserImage.Commands.DeleteUserImage;

public class DeleteUserImageCommandHandler:IRequestHandler<DeleteUserImageCommandRequest,DeleteUserImageCommandResponse>
{
    private readonly IUserImageRepository _UserImageRepository;
    private IMapper _mapper;

    public DeleteUserImageCommandHandler(IUserImageRepository userImageRepository, IMapper mapper)
    {
        _UserImageRepository = userImageRepository;
        _mapper = mapper;
    }

    public async Task<DeleteUserImageCommandResponse> Handle(DeleteUserImageCommandRequest request, CancellationToken cancellationToken)
    {
        UserImageFile userImage = _mapper.Map<UserImageFile>(request);
        UserImageFile deletedUserImage =
            await _UserImageRepository.DeleteAsync(userImage);
        DeleteUserImageCommandResponse deletedUserImageDto =
            _mapper.Map<DeleteUserImageCommandResponse>(deletedUserImage);
        return deletedUserImageDto;
    }
}