using Application.Features.Quizzes.Quiz.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Commands.DeleteQuiz;

public class DeleteQuizCommand:IRequest<DeletedQuizDto>
{
    public int Id { get; set; }
    public class DeleteQuizCommandHandler:IRequestHandler<DeleteQuizCommand,DeletedQuizDto>
    {
        private readonly IQuizRepository _quizRepository;
        private IMapper _mapper;

        public DeleteQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<DeletedQuizDto> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Quiz quiz = _mapper.Map<Domain.Entities.Quizzes.Quiz>(request);
            Domain.Entities.Quizzes.Quiz deletedQuiz =
                await _quizRepository.DeleteAsync(quiz);
            DeletedQuizDto deletedQuizDto =
                _mapper.Map<DeletedQuizDto>(deletedQuiz);
            return deletedQuizDto;
        }
    }
}