using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetByIdSelectedAnswer;

public class GetByIdSelectedAnswerQueryHandler : IRequestHandler<GetByIdSelectedAnswerQueryRequest, GetByIdSelectedAnswerQueryResponse>
{
    private readonly ISelectedAnswerRepository _selectedAnswerRepository;
    private IMapper _mapper;

    public GetByIdSelectedAnswerQueryHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
    {
        _selectedAnswerRepository = selectedAnswerRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdSelectedAnswerQueryResponse> Handle(GetByIdSelectedAnswerQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.SelectedAnswer? selectedAnswer =
            await _selectedAnswerRepository.GetAsync(c => c.Id == request.Id);
        GetByIdSelectedAnswerQueryResponse getByIdSelectedAnswerDto =
            _mapper.Map<GetByIdSelectedAnswerQueryResponse>(selectedAnswer);
        return getByIdSelectedAnswerDto;
    }
}