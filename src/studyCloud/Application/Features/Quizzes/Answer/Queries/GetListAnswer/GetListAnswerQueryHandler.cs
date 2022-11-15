using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Answer.Models;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Quizzes.Answer.Queries.GetListAnswer;

public class GetListAnswerQueryHandler : IRequestHandler<GetListAnswerQueryRequest, AnswerListModel>
{
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public GetListAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<AnswerListModel> Handle(GetListAnswerQueryRequest request, CancellationToken cancellationToken)
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