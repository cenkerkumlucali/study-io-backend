using Application.Features.Quizzes.Question.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.CreateQuestion;

public class CreateQuestionCommand : IRequest<CreatedQuestionDto>
{
    public int QuizId { get; set; }
    public string Text { get; set; }

    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreatedQuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;


        public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<CreatedQuestionDto> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Question mappedQuestion = _mapper.Map<Domain.Entities.Quizzes.Question>(request);
            Domain.Entities.Quizzes.Question createdQuestion = await _questionRepository.AddAsync(mappedQuestion);
            CreatedQuestionDto mappedCreateQuestionDto = _mapper.Map<CreatedQuestionDto>(createdQuestion);
            return mappedCreateQuestionDto;
        }
    }
}