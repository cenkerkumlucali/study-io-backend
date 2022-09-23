using Application.Features.Users.UserImage.Dtos;
using Application.Services.Repositories.Feeds;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserImage.Commands.UpdateUserImage;

public class UpdateUserImageCommand : IRequest<UpdatedUserImageDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }

    public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand, UpdatedUserImageDto>
    {
        private readonly IUserImageRepository _userImageRepository;
        private IMapper _mapper;

        public UpdateUserImageCommandHandler(IUserImageRepository userImageRepository, IMapper mapper)
        {
            _userImageRepository = userImageRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedUserImageDto> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserImage userImage = _mapper.Map<Domain.Entities.Users.UserImage>(request);
            Domain.Entities.Users.UserImage createdUserImage =
                await _userImageRepository.UpdateAsync(userImage);
            UpdatedUserImageDto updatedUserImageDto =
                _mapper.Map<UpdatedUserImageDto>(createdUserImage);
            return updatedUserImageDto;
        }
    }
}