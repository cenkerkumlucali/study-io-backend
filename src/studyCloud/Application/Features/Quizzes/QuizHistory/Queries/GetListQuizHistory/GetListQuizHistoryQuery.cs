using Application.Features.Quizzes.QuizHistory.Models;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Queries.GetListQuizHistory;

public class GetListQuizHistoryQuery : IRequest<QuizHistoryListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListQuizHistoryQueryHandler : IRequestHandler<GetListQuizHistoryQuery, QuizHistoryListModel>
    {
        private readonly IQuizHistoryRepository _quizHistoryRepository;
        private IMapper _mapper;

        public GetListQuizHistoryQueryHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
        {
            _quizHistoryRepository = quizHistoryRepository;
            _mapper = mapper;
        }

        public async Task<QuizHistoryListModel> Handle(GetListQuizHistoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Quizzes.QuizHistory> quizHistory =
                await _quizHistoryRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            QuizHistoryListModel mappedQuizHistoryListModel =
                _mapper.Map<QuizHistoryListModel>(quizHistory);
            return mappedQuizHistoryListModel;
        }
    }
}