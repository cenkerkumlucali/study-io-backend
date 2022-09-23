using Application.Features.Quizzes.QuizHistory.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;

public class CreateQuizHistoryCommand : IRequest<CreatedQuizHistoryDto>
{
    public int UserId { get; set; }
    public int QuizId { get; set; }

    public class CreateQuizHistoryCommandHandler : IRequestHandler<CreateQuizHistoryCommand, CreatedQuizHistoryDto>
    {
        private readonly IQuizHistoryRepository _quizHistoryRepository;
        private readonly IMapper _mapper;


        public CreateQuizHistoryCommandHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
        {
            _quizHistoryRepository = quizHistoryRepository;
            _mapper = mapper;
        }

        public async Task<CreatedQuizHistoryDto> Handle(CreateQuizHistoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.QuizHistory mappedQuizHistory = _mapper.Map<Domain.Entities.Quizzes.QuizHistory>(request);
            Domain.Entities.Quizzes.QuizHistory createdQuizHistory = await _quizHistoryRepository.AddAsync(mappedQuizHistory);
            CreatedQuizHistoryDto mappedCreateQuizHistoryDto = _mapper.Map<CreatedQuizHistoryDto>(createdQuizHistory);
            return mappedCreateQuizHistoryDto;
        }
    }
}