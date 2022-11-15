using Application.Features.Users.UserImage.Dtos;
using Application.Services.Repositories.Users;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.UserImage.Commands.CreateUserImage;

public class CreateUserImageCommand:IRequest<CreatedUserImageDto>
{
    public int UserId { get; set; }
    public string ImagePath { get; set; }

    public class CreateUserImageCommandHandler:IRequestHandler<CreateUserImageCommand,CreatedUserImageDto>
    {
        private readonly IUserImageRepository _userImageRepository;
        private readonly IMapper _mapper;


        public CreateUserImageCommandHandler(IUserImageRepository userImageRepository, IMapper mapper)
        {
            _userImageRepository = userImageRepository;
            _mapper = mapper;
        }

        public async Task<CreatedUserImageDto> Handle(CreateUserImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Users.UserImageFile mappedUserImage = _mapper.Map<Domain.Entities.Users.UserImageFile>(request);
            Domain.Entities.Users.UserImageFile createdUserImage = await _userImageRepository.AddAsync(mappedUserImage);
            CreatedUserImageDto mappedCreateUserImageDto = _mapper.Map<CreatedUserImageDto>(createdUserImage);
            return mappedCreateUserImageDto;
        }
    }
}