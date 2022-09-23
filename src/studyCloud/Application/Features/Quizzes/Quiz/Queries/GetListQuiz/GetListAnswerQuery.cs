using Application.Features.Quizzes.Quiz.Models;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Queries.GetListQuiz;

public class GetListQuizQuery : IRequest<QuizListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListQuizQueryHandler : IRequestHandler<GetListQuizQuery, QuizListModel>
    {
        private readonly IQuizRepository _quizRepository;
        private IMapper _mapper;

        public GetListQuizQueryHandler(IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _mapper = mapper;
        }

        public async Task<QuizListModel> Handle(GetListQuizQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Quizzes.Quiz> quiz =
                await _quizRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            QuizListModel mappedQuizListModel =
                _mapper.Map<QuizListModel>(quiz);
            return mappedQuizListModel;
        }
    }
}