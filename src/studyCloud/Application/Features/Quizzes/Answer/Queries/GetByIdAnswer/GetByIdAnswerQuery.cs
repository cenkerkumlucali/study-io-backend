using Application.Features.Quizzes.Answer.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;

public class GetByIdAnswerQuery:IRequest<GetByIdAnswerDto>
{
    public int Id { get; set; }
    public class GetByIdAnswerQueryHandler:IRequestHandler<GetByIdAnswerQuery,GetByIdAnswerDto>
    {
        private readonly IAnswerRepository _answerRepository;
        private IMapper _mapper;

        public GetByIdAnswerQueryHandler(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAnswerDto> Handle(GetByIdAnswerQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Answer? answer =
                await _answerRepository.GetAsync(c => c.Id == request.Id);
            GetByIdAnswerDto getByIdAnswerDto =
                _mapper.Map<GetByIdAnswerDto>(answer);
            return getByIdAnswerDto;
        }
    }
}