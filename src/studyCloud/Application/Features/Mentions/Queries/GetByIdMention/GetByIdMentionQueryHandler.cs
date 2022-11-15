using Application.Features.Mentions.Dtos;
using Application.Services.Repositories.Mentions;
using AutoMapper;
using Domain.Entities.Mentions;
using MediatR;

namespace Application.Features.Mentions.Queries.GetByIdMention;

public class GetByIdMentionQueryHandler:IRequestHandler<GetByIdMentionQueryRequest,GetByIdMentionQueryResponse>
{
    private readonly IMentionRepository _mentionRepository;
    private IMapper _mapper;

    public GetByIdMentionQueryHandler(IMentionRepository mentionRepository, IMapper mapper)
    {
        _mentionRepository = mentionRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdMentionQueryResponse> Handle(GetByIdMentionQueryRequest request, CancellationToken cancellationToken)
    {
        Mention? mention =
            await _mentionRepository.GetAsync(c => c.Id == request.Id);
        GetByIdMentionQueryResponse getByIdMentionDto =
            _mapper.Map<GetByIdMentionQueryResponse>(mention);
        return getByIdMentionDto;
    }
}