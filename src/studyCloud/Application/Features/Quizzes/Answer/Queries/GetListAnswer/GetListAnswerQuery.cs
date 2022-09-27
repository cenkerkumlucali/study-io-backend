using Application.Features.Mentions.Models;
using Application.Features.Quizzes.Answer.Models;
using Application.Services.Repositories.Mentions;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities.Mentions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Quizzes.Answer.Queries.GetListAnswer;

public class GetListAnswerQuery : IRequest<AnswerListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAnswerQueryHandler : IRequestHandler<GetListAnswerQuery, AnswerListModel>
    {
        private readonly IAnswerRepository _answerRepository;
        private IMapper _mapper;

        public GetListAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<AnswerListModel> Handle(GetListAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Quizzes.Answer> answer =
                await _answerRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include:c=>c.Include(c=>c.Question));
            AnswerListModel mappedAnswerListModel =
                _mapper.Map<AnswerListModel>(answer);
            return mappedAnswerListModel;
        }
    }
}