using Application.Features.Users.UserImage.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserImage.Commands.DeleteUserImage;

public class DeleteUserImageCommand:IRequest<DeletedUserImageDto>
{
    public int Id { get; set; }
    public class DeleteUserImageCommandHandler:IRequestHandler<DeleteUserImageCommand,DeletedUserImageDto>
    {
        private readonly IUserImageRepository _UserImageRepository;
        private IMapper _mapper;

        public DeleteUserImageCommandHandler(IUserImageRepository userImageRepository, IMapper mapper)
        {
            _UserImageRepository = userImageRepository;
            _mapper = mapper;
        }

        public async Task<DeletedUserImageDto> Handle(DeleteUserImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserImageFile userImage = _mapper.Map<Domain.Entities.Users.UserImageFile>(request);
            Domain.Entities.Users.UserImageFile deletedUserImage =
                await _UserImageRepository.DeleteAsync(userImage);
            DeletedUserImageDto deletedUserImageDto =
                _mapper.Map<DeletedUserImageDto>(deletedUserImage);
            return deletedUserImageDto;
        }
    }
}