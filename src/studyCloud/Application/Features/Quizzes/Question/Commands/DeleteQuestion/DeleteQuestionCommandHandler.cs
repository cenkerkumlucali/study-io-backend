using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.DeleteQuestion;

public class DeleteQuestionCommandHandler:IRequestHandler<DeleteQuestionCommandRequest,DeleteQuestionCommandResponse>
{
    private readonly IQuestionRepository _questionRepository;
    private IMapper _mapper;

    public DeleteQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<DeleteQuestionCommandResponse> Handle(DeleteQuestionCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Question question = _mapper.Map<Domain.Entities.Quizzes.Question>(request);
        Domain.Entities.Quizzes.Question deletedQuestion =
            await _questionRepository.DeleteAsync(question);
        DeleteQuestionCommandResponse deletedQuestionDto =
            _mapper.Map<DeleteQuestionCommandResponse>(deletedQuestion);
        return deletedQuestionDto;
    }
}