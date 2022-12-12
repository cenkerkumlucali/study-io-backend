using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Answer.Commands.DeleteAnswer;

public class DeleteAnswerCommandHandler:IRequestHandler<DeleteAnswerCommandRequest,DeleteAnswerCommandResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public DeleteAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<DeleteAnswerCommandResponse> Handle(DeleteAnswerCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Answer answer = _mapper.Map<Domain.Entities.Quizzes.Answer>(request);
        Domain.Entities.Quizzes.Answer deletedAnswer =
            await _answerRepository.DeleteAsync(answer);
        DeleteAnswerCommandResponse deletedAnswerDto =
            _mapper.Map<DeleteAnswerCommandResponse>(deletedAnswer);
        return deletedAnswerDto;
    }
}