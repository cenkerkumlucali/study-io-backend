using Application.Repositories.Services.Mentions;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Mentions.Commands.CreateMention;

public class CreateMentionCommandHandler:IRequestHandler<CreateMentionCommandRequest,CreateMentionCommandResponse>
{
    private readonly IMentionRepository _mentionRepository;
    private readonly IMapper _mapper;


    public CreateMentionCommandHandler(IMentionRepository mentionRepository, IMapper mapper)
    {
        _mentionRepository = mentionRepository;
        _mapper = mapper;
    }

    public async Task<CreateMentionCommandResponse> Handle(CreateMentionCommandRequest request, CancellationToken cancellationToken)
    {
        Mention mappedMention = _mapper.Map<Mention>(request);
        Mention createdMention = await _mentionRepository.AddAsync(mappedMention);
        CreateMentionCommandResponse mappedCreateMentionDto = _mapper.Map<CreateMentionCommandResponse>(createdMention);
        return mappedCreateMentionDto;
    }
}