using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Queries.GetByIdQuizHistory;

public class GetByIdQuizHistoryQueryHandler : IRequestHandler<GetByIdQuizHistoryQueryRequest, GetByIdQuizHistoryQueryResponse>
{
    private readonly IQuizHistoryRepository _quizHistoryRepository;
    private IMapper _mapper;

    public GetByIdQuizHistoryQueryHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
    {
        _quizHistoryRepository = quizHistoryRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdQuizHistoryQueryResponse> Handle(GetByIdQuizHistoryQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.QuizHistory? quizHistory =
            await _quizHistoryRepository.GetAsync(c => c.Id == request.Id);
        GetByIdQuizHistoryQueryResponse getByIdQuizHistoryDto =
            _mapper.Map<GetByIdQuizHistoryQueryResponse>(quizHistory);
        return getByIdQuizHistoryDto;
    }
}