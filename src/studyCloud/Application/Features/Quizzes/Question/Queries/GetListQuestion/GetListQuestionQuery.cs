using Application.Features.Quizzes.Question.Models;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Quizzes.Question.Queries.GetListQuestion;

public class GetListQuestionQuery : IRequest<QuestionListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListQuestionQueryHandler : IRequestHandler<GetListQuestionQuery, QuestionListModel>
    {
        private readonly IQuestionRepository _questionRepository;
        private IMapper _mapper;

        public GetListQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<QuestionListModel> Handle(GetListQuestionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Quizzes.Question> question =
                await _questionRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            QuestionListModel mappedQuestionListModel =
                _mapper.Map<QuestionListModel>(question);
            return mappedQuestionListModel;
        }
    }
}