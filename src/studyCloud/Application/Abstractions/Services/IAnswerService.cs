using Domain.Entities.Quizzes;

namespace Application.Abstractions.Services;

public interface IAnswerService
{
    Task AddRange(List<Answer> answers);
}