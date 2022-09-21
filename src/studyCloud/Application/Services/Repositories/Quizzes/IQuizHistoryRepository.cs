using Core.Persistence.Repositories;
using Domain.Entities.Quizzes;

namespace Application.Services.Repositories.Quizzes;

public interface IQuizHistoryRepository:IAsyncRepository<QuizHistory>,IRepository<QuizHistory>
{
    
}