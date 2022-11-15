using Application.Features.Mentions.Dtos;
using Application.Services.Repositories.Mentions;
using AutoMapper;
using Domain.Entities.Mentions;
using MediatR;

namespace Application.Features.Mentions.Commands.UpdateMention;

public class UpdateMentionCommandHandler : IRequestHandler<UpdateMentionCommandRequest, UpdateMentionCommandResponse>
{
    private readonly IMentionRepository _mentionRepository;
    private IMapper _mapper;

    public UpdateMentionCommandHandler(IMentionRepository mentionRepository, IMapper mapper)
    {
        _mentionRepository = mentionRepository;
        _mapper = mapper;
    }

    public async Task<UpdateMentionCommandResponse> Handle(UpdateMentionCommandRequest request, CancellationToken cancellationToken)
    {
        Mention mention = _mapper.Map<Mention>(request);
        Mention createdMention =
            await _mentionRepository.UpdateAsync(mention);
        UpdateMentionCommandResponse updatedMentionDto =
            _mapper.Map<UpdateMentionCommandResponse>(createdMention);
        return updatedMentionDto;
    }
}