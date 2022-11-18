using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.SelectedAnswer.Models;
using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetListSelectedAnswer;

public class GetListSelectedAnswerQueryHandler : IRequestHandler<GetListSelectedAnswerQueryRequest, SelectedAnswerListModel>
{
    private readonly ISelectedAnswerRepository _selectedAnswerRepository;
    private IMapper _mapper;

    public GetListSelectedAnswerQueryHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
    {
        _selectedAnswerRepository = selectedAnswerRepository;
        _mapper = mapper;
    }

    public async Task<SelectedAnswerListModel> Handle(GetListSelectedAnswerQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Quizzes.SelectedAnswer> selectedAnswer =
            await _selectedAnswerRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        SelectedAnswerListModel mappedSelectedAnswerListModel =
            _mapper.Map<SelectedAnswerListModel>(selectedAnswer);
        return mappedSelectedAnswerListModel;
    }
}