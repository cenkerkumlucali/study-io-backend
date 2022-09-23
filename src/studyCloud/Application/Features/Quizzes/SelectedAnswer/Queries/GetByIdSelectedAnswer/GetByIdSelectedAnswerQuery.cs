using Application.Features.Quizzes.SelectedAnswer.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetByIdSelectedAnswer;

public class GetByIdSelectedAnswerQuery : IRequest<GetByIdSelectedAnswerDto>
{
    public int Id { get; set; }
    public class GetByIdSelectedAnswerQueryHandler : IRequestHandler<GetByIdSelectedAnswerQuery, GetByIdSelectedAnswerDto>
    {
        private readonly ISelectedAnswerRepository _selectedAnswerRepository;
        private IMapper _mapper;

        public GetByIdSelectedAnswerQueryHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
        {
            _selectedAnswerRepository = selectedAnswerRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdSelectedAnswerDto> Handle(GetByIdSelectedAnswerQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.SelectedAnswer? selectedAnswer =
                await _selectedAnswerRepository.GetAsync(c => c.Id == request.Id);
            GetByIdSelectedAnswerDto getByIdSelectedAnswerDto =
                _mapper.Map<GetByIdSelectedAnswerDto>(selectedAnswer);
            return getByIdSelectedAnswerDto;
        }
    }
}