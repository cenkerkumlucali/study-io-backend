using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommandRequest, CreateQuizCommandResponse>
{
    private readonly IQuizRepository _quizRepository;
    private readonly IMapper _mapper;


    public CreateQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public async Task<CreateQuizCommandResponse> Handle(CreateQuizCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Quiz mappedQuiz = _mapper.Map<Domain.Entities.Quizzes.Quiz>(request);
        Domain.Entities.Quizzes.Quiz createdQuiz = await _quizRepository.AddAsync(mappedQuiz);
        CreateQuizCommandResponse mappedCreateQuizDto = _mapper.Map<CreateQuizCommandResponse>(createdQuiz);
        return mappedCreateQuizDto;
    }
}