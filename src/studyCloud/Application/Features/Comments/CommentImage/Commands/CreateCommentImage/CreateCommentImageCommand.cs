using Application.Features.Comments.CommentImage.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentImage.Commands.CreateCommentImage;

public class CreateCommentImageCommand:IRequest<CreatedCommentImageDto>
{
    public int CommentId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }
    
    public class CreateCommentImageCommandHandler:IRequestHandler<CreateCommentImageCommand,CreatedCommentImageDto>
    {
        private readonly ICommentImageRepository _CommentImageRepository;
        private readonly IMapper _mapper;


        public CreateCommentImageCommandHandler(ICommentImageRepository CommentImageRepository, IMapper mapper)
        {
            _CommentImageRepository = CommentImageRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCommentImageDto> Handle(CreateCommentImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentImage mappedCommentImage = _mapper.Map<Domain.Entities.Comments.CommentImage>(request);
            Domain.Entities.Comments.CommentImage createdCommentImage = await _CommentImageRepository.AddAsync(mappedCommentImage);
            CreatedCommentImageDto mappedCreateCommentImageDto = _mapper.Map<CreatedCommentImageDto>(createdCommentImage);
            return mappedCreateCommentImageDto;
        }
    }
}