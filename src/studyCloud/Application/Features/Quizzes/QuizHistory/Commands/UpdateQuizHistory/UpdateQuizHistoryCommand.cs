using Application.Features.Quizzes.QuizHistory.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;

public class UpdateQuizHistoryCommand : IRequest<UpdatedQuizHistoryDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }

    public class UpdateQuizHistoryCommandHandler : IRequestHandler<UpdateQuizHistoryCommand, UpdatedQuizHistoryDto>
    {
        private readonly IQuizHistoryRepository _quizHistoryRepository;
        private IMapper _mapper;

        public UpdateQuizHistoryCommandHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
        {
            _quizHistoryRepository = quizHistoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedQuizHistoryDto> Handle(UpdateQuizHistoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.QuizHistory quizHistory = _mapper.Map<Domain.Entities.Quizzes.QuizHistory>(request);
            Domain.Entities.Quizzes.QuizHistory createdQuizHistory =
                await _quizHistoryRepository.UpdateAsync(quizHistory);
            UpdatedQuizHistoryDto updatedQuizHistoryDto =
                _mapper.Map<UpdatedQuizHistoryDto>(createdQuizHistory);
            return updatedQuizHistoryDto;
        }
    }
}