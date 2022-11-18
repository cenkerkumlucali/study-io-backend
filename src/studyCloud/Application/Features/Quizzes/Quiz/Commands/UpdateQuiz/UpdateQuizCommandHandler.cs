using Application.Repositories.Services.Quizzes;
using AutoMapper;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Commands.UpdateQuiz;

public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommandRequest, UpdateQuizCommandResponse>
{
    private readonly IQuizRepository _quizRepository;
    private IMapper _mapper;

    public UpdateQuizCommandHandler(IQuizRepository quizRepository, IMapper mapper)
    {
        _quizRepository = quizRepository;
        _mapper = mapper;
    }

    public async Task<UpdateQuizCommandResponse> Handle(UpdateQuizCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Quizzes.Quiz quiz = _mapper.Map<Domain.Entities.Quizzes.Quiz>(request);
        Domain.Entities.Quizzes.Quiz createdQuiz =
            await _quizRepository.UpdateAsync(quiz);
        UpdateQuizCommandResponse updatedQuizDto =
            _mapper.Map<UpdateQuizCommandResponse>(createdQuiz);
        return updatedQuizDto;
    }
}