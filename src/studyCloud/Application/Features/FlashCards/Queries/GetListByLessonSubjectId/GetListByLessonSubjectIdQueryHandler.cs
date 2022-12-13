using Application.Abstractions.Services.Paging;
using Application.Features.FlashCards.Models;
using Application.Repositories.Services.FlashCards;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.FlashCards.Queries.GetListByLessonSubjectId;

public class
    GetListByLessonSubjectIdQueryHandler : IRequestHandler<GetListByLessonSubjectIdQueryRequest,
        GetByLessonSubjectIdListModel>
{
    private readonly IFlashCardRepository _flashCardRepository;
    private IMapper _mapper;

    public GetListByLessonSubjectIdQueryHandler(IFlashCardRepository flashCardRepository, IMapper mapper)
    {
        _flashCardRepository = flashCardRepository;
        _mapper = mapper;
    }

    public async Task<GetByLessonSubjectIdListModel> Handle(GetListByLessonSubjectIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.FlashCard> flashCard = await _flashCardRepository.GetListAsync(
            c => c.LessonSubjectId == request.LessonSubjectId,
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            include: c => c.Include(c => c.LessonSubject));
        GetByLessonSubjectIdListModel? mappedFlashCard = _mapper.Map<GetByLessonSubjectIdListModel>(flashCard);
        return mappedFlashCard;
    }
}