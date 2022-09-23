using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;
using Application.Features.Quizzes.Question.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Question.Queries.GetByIdQuestion;

public class GetByIdQuestionQuery : IRequest<GetByIdQuestionDto>
{
    public int Id { get; set; }
    public class GetByIdQuestionQueryHandler : IRequestHandler<GetByIdQuestionQuery, GetByIdQuestionDto>
    {
        private readonly IQuestionRepository _questionRepository;
        private IMapper _mapper;

        public GetByIdQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdQuestionDto> Handle(GetByIdQuestionQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.Question? question =
                await _questionRepository.GetAsync(c => c.Id == request.Id);
            GetByIdQuestionDto getByIdQuestionDto =
                _mapper.Map<GetByIdQuestionDto>(question);
            return getByIdQuestionDto;
        }
    }
}