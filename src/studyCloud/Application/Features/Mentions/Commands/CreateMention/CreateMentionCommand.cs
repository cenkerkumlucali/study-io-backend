using Application.Features.Mentions.Dtos;
using Application.Services.Repositories.Mentions;
using AutoMapper;
using Domain.Entities.Mentions;
using Domain.Enums;
using MediatR;

namespace Application.Features.Mentions.Commands.CreateMention;

public class CreateMentionCommand:IRequest<CreatedMentionDto>
{
    public int AgentId { get; set; }
    public int TargetId { get; set; }
    public int PostId { get; set; }
    public int CommentId { get; set; }
    public MentionType MentionType { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public class CreateMentionCommandHandler:IRequestHandler<CreateMentionCommand,CreatedMentionDto>
    {
        private readonly IMentionRepository _mentionRepository;
        private readonly IMapper _mapper;


        public CreateMentionCommandHandler(IMentionRepository mentionRepository, IMapper mapper)
        {
            _mentionRepository = mentionRepository;
            _mapper = mapper;
        }

        public async Task<CreatedMentionDto> Handle(CreateMentionCommand request, CancellationToken cancellationToken)
        {
            Mention mappedMention = _mapper.Map<Mention>(request);
            Mention createdMention = await _mentionRepository.AddAsync(mappedMention);
            CreatedMentionDto mappedCreateMentionDto = _mapper.Map<CreatedMentionDto>(createdMention);
            return mappedCreateMentionDto;
        }
    }
}