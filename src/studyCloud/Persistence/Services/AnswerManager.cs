using Application.Abstractions.Services;
using Application.Repositories.Services.Quizzes;
using Domain.Entities.Quizzes;

namespace Persistence.Services;

public class AnswerManager:IAnswerService
{
    private readonly IAnswerRepository _answerRepository;

    public AnswerManager(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public async Task AddRange(List<Answer> answers)
    {
        await _answerRepository.AddRangeAsync(answers);
    }
}