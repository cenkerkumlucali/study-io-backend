using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.QuizHistory.Commands.DeleteQuizHistory;

public class DeleteQuizHistoryCommandHandler:IRequestHandler<DeleteQuizHistoryCommandRequest,DeleteQuizHistoryCommandResponse>
{
    private readonly IQuizHistoryRepository _quizHistoryRepository;
    private IMapper _mapper;

    public DeleteQuizHistoryCommandHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
    {
        _quizHistoryRepository = quizHistoryRepository;
        _mapper = mapper;
    }

    public async Task<DeleteQuizHistoryCommandResponse> Handle(DeleteQuizHistoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.QuizHistory quizHistory = _mapper.Map<Domain.Entities.Quizzes.QuizHistory>(request);
        Domain.Entities.Quizzes.QuizHistory deletedQuizHistory =
            await _quizHistoryRepository.DeleteAsync(quizHistory);
        DeleteQuizHistoryCommandResponse deletedQuizHistoryDto =
            _mapper.Map<DeleteQuizHistoryCommandResponse>(deletedQuizHistory);
        return deletedQuizHistoryDto;
    }
}