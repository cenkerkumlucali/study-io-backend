using Application.Abstractions.Services.Paging;
using Application.Features.Mentions.Models;
using Application.Services.Repositories.Mentions;
using AutoMapper;
using Domain.Entities.Mentions;
using MediatR;

namespace Application.Features.Mentions.Queries.GetListMention;

public class GetListMentionQueryHandler : IRequestHandler<GetListMentionQueryRequest, MentionListModel>
{
    private readonly IMentionRepository _mentionRepository;
    private IMapper _mapper;

    public GetListMentionQueryHandler(IMentionRepository mentionRepository, IMapper mapper)
    {
        _mentionRepository = mentionRepository;
        _mapper = mapper;
    }

    public async Task<MentionListModel> Handle(GetListMentionQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Mention> mention =
            await _mentionRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        MentionListModel mappedMentionListModel =
            _mapper.Map<MentionListModel>(mention);
        return mappedMentionListModel;
    }
}