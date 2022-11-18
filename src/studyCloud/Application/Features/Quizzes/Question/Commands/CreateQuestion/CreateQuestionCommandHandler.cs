using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, CreateQuestionCommandResponse>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;


    public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Question mappedQuestion = _mapper.Map<Domain.Entities.Quizzes.Question>(request);
        Domain.Entities.Quizzes.Question createdQuestion = await _questionRepository.AddAsync(mappedQuestion);
        CreateQuestionCommandResponse mappedCreateQuestionDto = _mapper.Map<CreateQuestionCommandResponse>(createdQuestion);
        return mappedCreateQuestionDto;
    }
}