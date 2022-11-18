using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;

public class GetByIdAnswerQueryHandler:IRequestHandler<GetByIdAnswerQueryRequest,GetByIdAnswerQueryResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private IMapper _mapper;

    public GetByIdAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdAnswerQueryResponse> Handle(GetByIdAnswerQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Answer? answer =
            await _answerRepository.GetAsync(c => c.Id == request.Id);
        GetByIdAnswerQueryResponse getByIdAnswerDto =
            _mapper.Map<GetByIdAnswerQueryResponse>(answer);
        return getByIdAnswerDto;
    }
}