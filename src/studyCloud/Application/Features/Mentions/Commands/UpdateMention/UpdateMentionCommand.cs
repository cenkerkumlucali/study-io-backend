using Application.Features.Follows.Dtos;
using Application.Features.Mentions.Dtos;
using Application.Services.Repositories.Follows;
using Application.Services.Repositories.Mentions;
using AutoMapper;
using Domain.Entities.Follow;
using Domain.Entities.Mentions;
using Domain.Enums;
using MediatR;

namespace Application.Features.Mentions.Commands.UpdateMention;

public class UpdateMentionCommand : IRequest<UpdatedMentionDto>
{
    public int Id { get; set; }
    public int AgentId { get; set; }
    public int TargetId { get; set; }
    public int PostId { get; set; }
    public int CommentId { get; set; }
    public MentionType MentionType { get; set; }
    public DateTime CreatedDate { get; set; }

    public class UpdateMentionCommandHandler : IRequestHandler<UpdateMentionCommand, UpdatedMentionDto>
    {
        private readonly IMentionRepository _mentionRepository;
        private IMapper _mapper;

        public UpdateMentionCommandHandler(IMentionRepository mentionRepository, IMapper mapper)
        {
            _mentionRepository = mentionRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedMentionDto> Handle(UpdateMentionCommand request, CancellationToken cancellationToken)
        {
            Mention mention = _mapper.Map<Mention>(request);
            Mention createdMention =
                await _mentionRepository.UpdateAsync(mention);
            UpdatedMentionDto updatedMentionDto =
                _mapper.Map<UpdatedMentionDto>(createdMention);
            return updatedMentionDto;
        }
    }
}