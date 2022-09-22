using Application.Features.Quizzes.Answer.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.CreateAnswer;

public class CreateAnswerCommand : IRequest<CreatedAnswerDto>
{
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreatedAnswerDto>
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;


        public CreateAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<CreatedAnswerDto> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Answer mappedAnswer = _mapper.Map<Domain.Entities.Quizzes.Answer>(request);
            Domain.Entities.Quizzes.Answer createdAnswer = await _answerRepository.AddAsync(mappedAnswer);
            CreatedAnswerDto mappedCreateAnswerDto = _mapper.Map<CreatedAnswerDto>(createdAnswer);
            return mappedCreateAnswerDto;
        }
    }
}