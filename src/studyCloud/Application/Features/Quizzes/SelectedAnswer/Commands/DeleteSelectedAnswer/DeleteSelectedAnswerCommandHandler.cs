using Application.Features.Quizzes.SelectedAnswer.Dtos;
using Application.Services.Repositories.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.DeleteSelectedAnswer;

public class DeleteSelectedAnswerCommandHandler:IRequestHandler<DeleteSelectedAnswerCommandRequest,DeleteSelectedAnswerCommandResponse>
{
    private readonly ISelectedAnswerRepository _selectedAnswerRepository;
    private IMapper _mapper;

    public DeleteSelectedAnswerCommandHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
    {
        _selectedAnswerRepository = selectedAnswerRepository;
        _mapper = mapper;
    }

    public async Task<DeleteSelectedAnswerCommandResponse> Handle(DeleteSelectedAnswerCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.SelectedAnswer selectedAnswer = _mapper.Map<Domain.Entities.Quizzes.SelectedAnswer>(request);
        Domain.Entities.Quizzes.SelectedAnswer deletedSelectedAnswer =
            await _selectedAnswerRepository.DeleteAsync(selectedAnswer);
        DeleteSelectedAnswerCommandResponse deletedSelectedAnswerDto =
            _mapper.Map<DeleteSelectedAnswerCommandResponse>(deletedSelectedAnswer);
        return deletedSelectedAnswerDto;
    }
}