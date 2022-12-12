using Application.Abstractions.Services.Paging;
using Application.Features.Question.Models;
using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Question.Queries.GetListByQuizId;

public class GetListByQuizIdQueryHandler:IRequestHandler<GetListByQuizIdQueryRequest,GetByQuizIdModel>
{
    private readonly IQuestionRepository _questionRepository;
    private IMapper _mapper;

    public GetListByQuizIdQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<GetByQuizIdModel> Handle(GetListByQuizIdQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Quizzes.Question> questions =
            await _questionRepository.GetListAsync(c => c.QuizId == request.QuizId,
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include:c=>c.Include(c=>c.Answers)
                    .Include(c=>c.QuestionImages));
        GetByQuizIdModel mappedQuestion =
            _mapper.Map<GetByQuizIdModel>(questions);
        return mappedQuestion;
    }
}