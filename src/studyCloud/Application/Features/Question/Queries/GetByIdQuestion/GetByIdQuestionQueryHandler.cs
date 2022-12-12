using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Question.Queries.GetByIdQuestion;

public class GetByIdQuestionQueryHandler : IRequestHandler<GetByIdQuestionQueryRequest, GetByIdQuestionQueryResponse>
{
    private readonly IQuestionRepository _questionRepository;
    private IMapper _mapper;

    public GetByIdQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdQuestionQueryResponse> Handle(GetByIdQuestionQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Question? question =
            await _questionRepository.GetAsync(c => c.Id == request.Id);
        GetByIdQuestionQueryResponse getByIdQuestionDto =
            _mapper.Map<GetByIdQuestionQueryResponse>(question);
        return getByIdQuestionDto;
    }
}