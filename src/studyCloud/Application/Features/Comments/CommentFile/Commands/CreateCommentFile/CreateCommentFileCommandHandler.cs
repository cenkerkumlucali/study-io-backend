using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.CreateCommentFile;

public class CreateCommentFileCommandHandler:IRequestHandler<CreateCommentFileCommandRequest,CreateCommentFileCommandResponse>
{
    private readonly ICommentImageRepository _CommentImageRepository;
    private readonly IMapper _mapper;


    public CreateCommentFileCommandHandler(ICommentImageRepository CommentImageRepository, IMapper mapper)
    {
        _CommentImageRepository = CommentImageRepository;
        _mapper = mapper;
    }

    public async Task<CreateCommentFileCommandResponse> Handle(CreateCommentFileCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentImageFile mappedCommentImage = _mapper.Map<Domain.Entities.Comments.CommentImageFile>(request);
        Domain.Entities.Comments.CommentImageFile createdCommentImage = await _CommentImageRepository.AddAsync(mappedCommentImage);
        CreateCommentFileCommandResponse mappedCreateCommentImageDto = _mapper.Map<CreateCommentFileCommandResponse>(createdCommentImage);
        return mappedCreateCommentImageDto;
    }
}