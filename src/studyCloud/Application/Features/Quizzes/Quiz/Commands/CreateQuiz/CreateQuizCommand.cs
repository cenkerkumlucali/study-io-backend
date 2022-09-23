using Application.Features.Quizzes.Quiz.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Commands.CreateQuiz;

public class CreateQuizCommand : IRequest<CreatedQuizDto>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }

    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, CreatedQuizDto>
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;


        public CreateQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<CreatedQuizDto> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Quiz mappedQuiz = _mapper.Map<Domain.Entities.Quizzes.Quiz>(request);
            Domain.Entities.Quizzes.Quiz createdQuiz = await _quizRepository.AddAsync(mappedQuiz);
            CreatedQuizDto mappedCreateQuizDto = _mapper.Map<CreatedQuizDto>(createdQuiz);
            return mappedCreateQuizDto;
        }
    }
}