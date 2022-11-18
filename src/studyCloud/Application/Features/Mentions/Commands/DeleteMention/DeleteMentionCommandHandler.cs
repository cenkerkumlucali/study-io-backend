using Application.Repositories.Services.Mentions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mentions.Commands.DeleteMention;

public class DeleteMentionCommandHandler:IRequestHandler<DeleteMentionCommandRequest,DeleteMentionCommandResponse>
{
    private readonly IMentionRepository _mentionRepository;
    private IMapper _mapper;

    public DeleteMentionCommandHandler(IMentionRepository mentionRepository, IMapper mapper)
    {
        _mentionRepository = mentionRepository;
        _mapper = mapper;
    }

    public async Task<DeleteMentionCommandResponse> Handle(DeleteMentionCommandRequest request, CancellationToken cancellationToken)
    {
        Mention mention = _mapper.Map<Mention>(request);
        Mention deletedMention =
            await _mentionRepository.DeleteAsync(mention);
        DeleteMentionCommandResponse deletedMentionDto =
            _mapper.Map<DeleteMentionCommandResponse>(deletedMention);
        return deletedMentionDto;
    }
}