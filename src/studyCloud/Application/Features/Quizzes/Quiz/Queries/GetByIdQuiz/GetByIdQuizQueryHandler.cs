using Application.Features.Quizzes.Quiz.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Queries.GetByIdQuiz;

public class GetByIdQuizQueryHandler:IRequestHandler<GetByIdQuizQueryRequest,GetByIdQuizQueryResponse>
{
    private readonly IQuizRepository _quizRepository;
    private IMapper _mapper;

    public GetByIdQuizQueryHandler(IQuizRepository quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdQuizQueryResponse> Handle(GetByIdQuizQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Quiz? quiz =
            await _quizRepository.GetAsync(c => c.Id == request.Id);
        GetByIdQuizQueryResponse getByIdQuizDto =
            _mapper.Map<GetByIdQuizQueryResponse>(quiz);
        return getByIdQuizDto;
    }
}