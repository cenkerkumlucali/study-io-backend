using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.SelectedAnswer.Commands.CreateSelectedAnswer;

public class CreateSelectedAnswerCommandHandler : IRequestHandler<CreateSelectedAnswerCommandRequest, CreateSelectedAnswerCommandResponse>
{
    private readonly ISelectedAnswerRepository _selectedAnswerRepository;
    private readonly IMapper _mapper;


    public CreateSelectedAnswerCommandHandler(ISelectedAnswerRepository selectedAnswerRepository, IMapper mapper)
    {
        _selectedAnswerRepository = selectedAnswerRepository;
        _mapper = mapper;
    }

    public async Task<CreateSelectedAnswerCommandResponse> Handle(CreateSelectedAnswerCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.SelectedAnswer mappedSelectedAnswer = _mapper.Map<Domain.Entities.Quizzes.SelectedAnswer>(request);
        Domain.Entities.Quizzes.SelectedAnswer createdSelectedAnswer = await _selectedAnswerRepository.AddAsync(mappedSelectedAnswer);
        CreateSelectedAnswerCommandResponse mappedCreateSelectedAnswerDto = _mapper.Map<CreateSelectedAnswerCommandResponse>(createdSelectedAnswer);
        return mappedCreateSelectedAnswerDto;
    }
}