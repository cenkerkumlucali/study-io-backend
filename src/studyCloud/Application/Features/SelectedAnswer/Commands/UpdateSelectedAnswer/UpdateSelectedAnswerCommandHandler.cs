using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.SelectedAnswer.Commands.UpdateSelectedAnswer;

public class UpdateSelectedAnswerCommandHandler : IRequestHandler<UpdateSelectedAnswerCommandRequest, UpdateSelectedAnswerCommandResponse>
{
    private readonly ISelectedAnswerRepository _selectedAnswerRepository;
    private IMapper _mapper;

    public UpdateSelectedAnswerCommandHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
    {
        _selectedAnswerRepository = selectedAnswerRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSelectedAnswerCommandResponse> Handle(UpdateSelectedAnswerCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.SelectedAnswer selectedAnswer = _mapper.Map<Domain.Entities.Quizzes.SelectedAnswer>(request);
        Domain.Entities.Quizzes.SelectedAnswer createdSelectedAnswer =
            await _selectedAnswerRepository.UpdateAsync(selectedAnswer);
        UpdateSelectedAnswerCommandResponse updatedSelectedAnswerDto =
            _mapper.Map<UpdateSelectedAnswerCommandResponse>(createdSelectedAnswer);
        return updatedSelectedAnswerDto;
    }
}