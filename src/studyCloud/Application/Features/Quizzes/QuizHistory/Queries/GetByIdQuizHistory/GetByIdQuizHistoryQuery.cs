using Application.Features.Quizzes.QuizHistory.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Queries.GetByIdQuizHistory;

public class GetByIdQuizHistoryQuery : IRequest<GetByIdQuizHistoryDto>
{
    public int Id { get; set; }
    public class GetByIdQuizHistoryQueryHandler : IRequestHandler<GetByIdQuizHistoryQuery, GetByIdQuizHistoryDto>
    {
        private readonly IQuizHistoryRepository _quizHistoryRepository;
        private IMapper _mapper;

        public GetByIdQuizHistoryQueryHandler(IQuizHistoryRepository quizHistoryRepository, IMapper mapper)
        {
            _quizHistoryRepository = quizHistoryRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdQuizHistoryDto> Handle(GetByIdQuizHistoryQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.QuizHistory? quizHistory =
                await _quizHistoryRepository.GetAsync(c => c.Id == request.Id);
            GetByIdQuizHistoryDto getByIdQuizHistoryDto =
                _mapper.Map<GetByIdQuizHistoryDto>(quizHistory);
            return getByIdQuizHistoryDto;
        }
    }
}