using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.UpdateAnswer;

public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommandRequest, UpdatedAnswerCommandResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public UpdateAnswerCommandHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedAnswerCommandResponse> Handle(UpdateAnswerCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Answer answer = _mapper.Map<Domain.Entities.Quizzes.Answer>(request);
        Domain.Entities.Quizzes.Answer createdAnswer =
            await _answerRepository.UpdateAsync(answer);
        UpdatedAnswerCommandResponse updatedAnswerDto =
            _mapper.Map<UpdatedAnswerCommandResponse>(createdAnswer);
        return updatedAnswerDto;
    }
}