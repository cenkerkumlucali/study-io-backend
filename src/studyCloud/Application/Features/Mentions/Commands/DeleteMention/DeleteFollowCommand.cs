using Application.Features.Mentions.Dtos;
using Application.Services.Repositories.Mentions;
using AutoMapper;
using Domain.Entities.Mentions;
using MediatR;

namespace Application.Features.Mentions.Commands.DeleteMention;

public class DeleteMentionCommand:IRequest<DeletedMentionDto>
{
    public int Id { get; set; }
    public class DeleteMentionCommandHandler:IRequestHandler<DeleteMentionCommand,DeletedMentionDto>
    {
        private readonly IMentionRepository _mentionRepository;
        private IMapper _mapper;

        public DeleteMentionCommandHandler(IMentionRepository mentionRepository, IMapper mapper)
        {
            _mentionRepository = mentionRepository;
            _mapper = mapper;
        }

        public async Task<DeletedMentionDto> Handle(DeleteMentionCommand request, CancellationToken cancellationToken)
        {
            Mention mention = _mapper.Map<Mention>(request);
            Mention deletedMention =
                await _mentionRepository.DeleteAsync(mention);
            DeletedMentionDto deletedMentionDto =
                _mapper.Map<DeletedMentionDto>(deletedMention);
            return deletedMentionDto;
        }
    }
}