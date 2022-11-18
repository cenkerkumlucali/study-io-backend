using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Question.Models;
using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Queries.GetListQuestion;

public class GetListQuestionQueryHandler : IRequestHandler<GetListQuestionQueryRequest, QuestionListModel>
{
    private readonly IQuestionRepository _questionRepository;
    private IMapper _mapper;

    public GetListQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuestionListModel> Handle(GetListQuestionQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Quizzes.Question> question =
            await _questionRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        QuestionListModel mappedQuestionListModel =
            _mapper.Map<QuestionListModel>(question);
        return mappedQuestionListModel;
    }
}