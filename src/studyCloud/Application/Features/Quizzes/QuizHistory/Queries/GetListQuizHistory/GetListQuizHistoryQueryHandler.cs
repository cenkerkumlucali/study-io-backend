using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.QuizHistory.Models;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Queries.GetListQuizHistory;

public class GetListQuizHistoryQueryHandler : IRequestHandler<GetListQuizHistoryQueryRequest, QuizHistoryListModel>
{
    private readonly IQuizHistoryRepository _quizHistoryRepository;
    private IMapper _mapper;

    public GetListQuizHistoryQueryHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
    {
        _quizHistoryRepository = quizHistoryRepository;
        _mapper = mapper;
    }

    public async Task<QuizHistoryListModel> Handle(GetListQuizHistoryQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Quizzes.QuizHistory> quizHistory =
            await _quizHistoryRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        QuizHistoryListModel mappedQuizHistoryListModel =
            _mapper.Map<QuizHistoryListModel>(quizHistory);
        return mappedQuizHistoryListModel;
    }
}