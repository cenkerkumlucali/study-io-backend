using Application.Features.Quizzes.Question.Dtos;
using Application.Features.Quizzes.QuizHistory.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.DeleteQuizHistory;

public class DeleteQuizHistoryCommand:IRequest<DeletedQuizHistoryDto>
{
    public int Id { get; set; }
    public class DeleteQuizHistoryCommandHandler:IRequestHandler<DeleteQuizHistoryCommand,DeletedQuizHistoryDto>
    {
        private readonly IQuizHistoryRepository _quizHistoryRepository;
        private IMapper _mapper;

        public DeleteQuizHistoryCommandHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
        {
            _quizHistoryRepository = quizHistoryRepository;
            _mapper = mapper;
        }

        public async Task<DeletedQuizHistoryDto> Handle(DeleteQuizHistoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.QuizHistory quizHistory = _mapper.Map<Domain.Entities.Quizzes.QuizHistory>(request);
            Domain.Entities.Quizzes.QuizHistory deletedQuizHistory =
                await _quizHistoryRepository.DeleteAsync(quizHistory);
            DeletedQuizHistoryDto deletedQuizHistoryDto =
                _mapper.Map<DeletedQuizHistoryDto>(deletedQuizHistory);
            return deletedQuizHistoryDto;
        }
    }
}