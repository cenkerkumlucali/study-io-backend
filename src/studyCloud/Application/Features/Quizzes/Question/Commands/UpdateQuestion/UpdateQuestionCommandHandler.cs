using Application.Features.Quizzes.Question.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.UpdateQuestion;

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommandRequest, UpdateQuestionCommandResponse>
{
    private readonly IQuestionRepository _questionRepository;
    private IMapper _mapper;

    public UpdateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<UpdateQuestionCommandResponse> Handle(UpdateQuestionCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Question question = _mapper.Map<Domain.Entities.Quizzes.Question>(request);
        Domain.Entities.Quizzes.Question createdQuestion =
            await _questionRepository.UpdateAsync(question);
        UpdateQuestionCommandResponse updatedQuestionDto =
            _mapper.Map<UpdateQuestionCommandResponse>(createdQuestion);
        return updatedQuestionDto;
    }
}