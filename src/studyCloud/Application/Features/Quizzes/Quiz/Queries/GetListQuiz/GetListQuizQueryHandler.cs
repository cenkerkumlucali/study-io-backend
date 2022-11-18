using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Quiz.Models;
using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Queries.GetListQuiz;

public class GetListQuizQueryHandler : IRequestHandler<GetListQuizQueryRequest, QuizListModel>
{
    private readonly IQuizRepository _quizRepository;
    private IMapper _mapper;

    public GetListQuizQueryHandler(IQuizRepository quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public async Task<QuizListModel> Handle(GetListQuizQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Quizzes.Quiz> quiz =
            await _quizRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        QuizListModel mappedQuizListModel =
            _mapper.Map<QuizListModel>(quiz);
        return mappedQuizListModel;
    }
}