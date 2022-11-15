using Application.Features.Quizzes.QuizHistory.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;

public class CreateQuizHistoryCommandHandler : IRequestHandler<CreateQuizHistoryCommandRequest, CreateQuizHistoryCommandResponse>
{
    private readonly IQuizHistoryRepository _quizHistoryRepository;
    private readonly IMapper _mapper;


    public CreateQuizHistoryCommandHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
    {
        _quizHistoryRepository = quizHistoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateQuizHistoryCommandResponse> Handle(CreateQuizHistoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.QuizHistory mappedQuizHistory = _mapper.Map<Domain.Entities.Quizzes.QuizHistory>(request);
        Domain.Entities.Quizzes.QuizHistory createdQuizHistory = await _quizHistoryRepository.AddAsync(mappedQuizHistory);
        CreateQuizHistoryCommandResponse mappedCreateQuizHistoryDto = _mapper.Map<CreateQuizHistoryCommandResponse>(createdQuizHistory);
        return mappedCreateQuizHistoryDto;
    }
}