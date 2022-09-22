using Application.Features.Comments.CommentImage.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentImage.Commands.UpdateCommentImage;

public class UpdateCommentImageCommand:IRequest<UpdatedCommentImageDto>
{
    public int Id { get; set; }
    public int CommentId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }
    
    public class UpdateCommentImageCommandHandler:IRequestHandler<UpdateCommentImageCommand,UpdatedCommentImageDto>
    {
        private ICommentImageRepository _commentImageRepository;
        private IMapper _mapper;

        public UpdateCommentImageCommandHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
        {
            _commentImageRepository = commentImageRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCommentImageDto> Handle(UpdateCommentImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentImage commentImage = _mapper.Map<Domain.Entities.Comments.CommentImage>(request);
            Domain.Entities.Comments.CommentImage createdCommentImage =
                await _commentImageRepository.UpdateAsync(commentImage);
            UpdatedCommentImageDto  updatedCommentImageDto =
                _mapper.Map<UpdatedCommentImageDto>(createdCommentImage);
            return updatedCommentImageDto;
        }
    }
}