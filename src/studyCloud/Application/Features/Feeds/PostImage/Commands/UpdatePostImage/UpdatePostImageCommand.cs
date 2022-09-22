using Application.Features.Feeds.PostImage.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.UpdatePostImage;

public class UpdatePostImageCommand : IRequest<UpdatedPostImageDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    public class UpdatePostImageCommandHandler : IRequestHandler<UpdatePostImageCommand, UpdatedPostImageDto>
    {
        private readonly IPostImageRepository _postImageRepository;
        private IMapper _mapper;

        public UpdatePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedPostImageDto> Handle(UpdatePostImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostImage postImage = _mapper.Map<Domain.Entities.Feeds.PostImage>(request);
            Domain.Entities.Feeds.PostImage createdPostImage =
                await _postImageRepository.UpdateAsync(postImage);
            UpdatedPostImageDto updatedPostImageDto =
                _mapper.Map<UpdatedPostImageDto>(createdPostImage);
            return updatedPostImageDto;
        }
    }
}