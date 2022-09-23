using Application.Features.Quizzes.SelectedAnswer.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.UpdateSelectedAnswer;

public class UpdateSelectedAnswerCommand : IRequest<UpdatedSelectedAnswerDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }

    public class UpdateSelectedAnswerCommandHandler : IRequestHandler<UpdateSelectedAnswerCommand, UpdatedSelectedAnswerDto>
    {
        private readonly ISelectedAnswerRepository _selectedAnswerRepository;
        private IMapper _mapper;

        public UpdateSelectedAnswerCommandHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
        {
            _selectedAnswerRepository = selectedAnswerRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedSelectedAnswerDto> Handle(UpdateSelectedAnswerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Quizzes.SelectedAnswer selectedAnswer = _mapper.Map<Domain.Entities.Quizzes.SelectedAnswer>(request);
            Domain.Entities.Quizzes.SelectedAnswer createdSelectedAnswer =
                await _selectedAnswerRepository.UpdateAsync(selectedAnswer);
            UpdatedSelectedAnswerDto updatedSelectedAnswerDto =
                _mapper.Map<UpdatedSelectedAnswerDto>(createdSelectedAnswer);
            return updatedSelectedAnswerDto;
        }
    }
}