using Application.Features.Quizzes.SelectedAnswer.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.CreateSelectedAnswer;

public class CreateSelectedAnswerCommand : IRequest<CreatedSelectedAnswerDto>
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }

    public class CreateSelectedAnswerCommandHandler : IRequestHandler<CreateSelectedAnswerCommand, CreatedSelectedAnswerDto>
    {
        private readonly ISelectedAnswerRepository _selectedAnswerRepository;
        private readonly IMapper _mapper;


        public CreateSelectedAnswerCommandHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
        {
            _selectedAnswerRepository = selectedAnswerRepository;
            _mapper = mapper;
        }

        public async Task<CreatedSelectedAnswerDto> Handle(CreateSelectedAnswerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.SelectedAnswer mappedSelectedAnswer = _mapper.Map<Domain.Entities.Quizzes.SelectedAnswer>(request);
            Domain.Entities.Quizzes.SelectedAnswer createdSelectedAnswer = await _selectedAnswerRepository.AddAsync(mappedSelectedAnswer);
            CreatedSelectedAnswerDto mappedCreateSelectedAnswerDto = _mapper.Map<CreatedSelectedAnswerDto>(createdSelectedAnswer);
            return mappedCreateSelectedAnswerDto;
        }
    }
}