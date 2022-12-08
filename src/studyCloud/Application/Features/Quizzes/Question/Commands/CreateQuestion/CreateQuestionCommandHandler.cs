using Application.Abstractions.Services;
using Application.Features.Quizzes.Answer.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, CreateQuestionCommandResponse>
{
    private readonly IQuestionService _questionService;
    private readonly IQuestionImageService _questionImageService;
    private readonly IAnswerService _answerService;
    private readonly IMapper _mapper;


    public CreateQuestionCommandHandler(IMapper mapper, IQuestionService questionService, IAnswerService answerService, IQuestionImageService questionImageService)
    {
        _mapper = mapper;
        _questionService = questionService;
        _answerService = answerService;
        _questionImageService = questionImageService;
    }

    public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Question mappedQuestion = _mapper.Map<Domain.Entities.Quizzes.Question>(request);
        Domain.Entities.Quizzes.Question createdQuestion = await _questionService.AddAsync(mappedQuestion,request.Files);
        request.CreateAnswerDtos?.ForEach(delegate(AnswerDto dto)
        {
            dto.questionId = dto.questionId = createdQuestion.Id;
        });
        List<Domain.Entities.Quizzes.Answer>? mappedCreateAnswerDto = _mapper.Map<List<Domain.Entities.Quizzes.Answer>>(request.CreateAnswerDtos);
        await _answerService.AddRange(mappedCreateAnswerDto);
        await _questionImageService.Upload(createdQuestion.Id,request.Files);
        CreateQuestionCommandResponse mappedCreateQuestionDto = _mapper.Map<CreateQuestionCommandResponse>(createdQuestion);
        return mappedCreateQuestionDto;
    }
}