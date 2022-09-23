using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Quiz.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Queries.GetByIdQuiz;

public class GetByIdQuizQuery:IRequest<GetByIdQuizDto>
{
    public int Id { get; set; }
    public class GetByIdQuizQueryHandler:IRequestHandler<GetByIdQuizQuery,GetByIdQuizDto>
    {
        private readonly IQuizRepository _quizRepository;
        private IMapper _mapper;

        public GetByIdQuizQueryHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdQuizDto> Handle(GetByIdQuizQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Quiz? quiz =
                await _quizRepository.GetAsync(c => c.Id == request.Id);
            GetByIdQuizDto getByIdQuizDto =
                _mapper.Map<GetByIdQuizDto>(quiz);
            return getByIdQuizDto;
        }
    }
}