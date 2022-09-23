using Application.Features.Quizzes.SelectedAnswer.Models;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetListSelectedAnswer;

public class GetListSelectedAnswerQuery : IRequest<SelectedAnswerListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSelectedAnswerQueryHandler : IRequestHandler<GetListSelectedAnswerQuery, SelectedAnswerListModel>
    {
        private readonly ISelectedAnswerRepository _selectedAnswerRepository;
        private IMapper _mapper;

        public GetListSelectedAnswerQueryHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
        {
            _selectedAnswerRepository = selectedAnswerRepository;
            _mapper = mapper;
        }

        public async Task<SelectedAnswerListModel> Handle(GetListSelectedAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Quizzes.SelectedAnswer> selectedAnswer =
                await _selectedAnswerRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            SelectedAnswerListModel mappedSelectedAnswerListModel =
                _mapper.Map<SelectedAnswerListModel>(selectedAnswer);
            return mappedSelectedAnswerListModel;
        }
    }
}