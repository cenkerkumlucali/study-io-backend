using Domain.Entities.Quizzes;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Services;

public interface IQuestionService
{
    Task<Question> AddAsync(Question question, IFormFileCollection files);
}