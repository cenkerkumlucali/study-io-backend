using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Follows.Dtos;
using Application.Features.Mentions.Dtos;
using Application.Services.Repositories.Feeds;
using Application.Services.Repositories.Follows;
using Application.Services.Repositories.Mentions;
using AutoMapper;
using Domain.Entities.Follow;
using Domain.Entities.Mentions;
using MediatR;

namespace Application.Features.Mentions.Queries.GetByIdMention;

public class GetByIdMentionQuery:IRequest<GetByIdMentionDto>
{
    public int Id { get; set; }
    public class GetByIdMentionQueryHandler:IRequestHandler<GetByIdMentionQuery,GetByIdMentionDto>
    {
        private readonly IMentionRepository _mentionRepository;
        private IMapper _mapper;

        public GetByIdMentionQueryHandler(IMentionRepository mentionRepository, IMapper mapper)
        {
            _mentionRepository = mentionRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdMentionDto> Handle(GetByIdMentionQuery request, CancellationToken cancellationToken)
        {
            Mention? mention =
                await _mentionRepository.GetAsync(c => c.Id == request.Id);
            GetByIdMentionDto getByIdMentionDto =
                _mapper.Map<GetByIdMentionDto>(mention);
            return getByIdMentionDto;
        }
    }
}