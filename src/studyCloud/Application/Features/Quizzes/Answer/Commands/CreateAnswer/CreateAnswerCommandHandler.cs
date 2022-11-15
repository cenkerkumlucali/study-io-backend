using Application.Features.Quizzes.Answer.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.CreateAnswer;

public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommandRequest, CreateAnswerCommandResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;


    public CreateAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Answer mappedAnswer = _mapper.Map<Domain.Entities.Quizzes.Answer>(request);
        Domain.Entities.Quizzes.Answer createdAnswer = await _answerRepository.AddAsync(mappedAnswer);
        CreateAnswerCommandResponse mappedCreateAnswerDto = _mapper.Map<CreateAnswerCommandResponse>(createdAnswer);
        return mappedCreateAnswerDto;
    }
}