using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;

public class UpdateQuizHistoryCommandHandler : IRequestHandler<UpdateQuizHistoryCommandRequest, UpdateQuizHistoryQueryResponse>
{
    private readonly IQuizHistoryRepository _quizHistoryRepository;
    private IMapper _mapper;

    public UpdateQuizHistoryCommandHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
    {
        _quizHistoryRepository = quizHistoryRepository;
        _mapper = mapper;
    }

    public async Task<UpdateQuizHistoryQueryResponse> Handle(UpdateQuizHistoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.QuizHistory quizHistory = _mapper.Map<Domain.Entities.Quizzes.QuizHistory>(request);
        Domain.Entities.Quizzes.QuizHistory createdQuizHistory =
            await _quizHistoryRepository.UpdateAsync(quizHistory);
        UpdateQuizHistoryQueryResponse updatedQuizHistoryDto =
            _mapper.Map<UpdateQuizHistoryQueryResponse>(createdQuizHistory);
        return updatedQuizHistoryDto;
    }
}