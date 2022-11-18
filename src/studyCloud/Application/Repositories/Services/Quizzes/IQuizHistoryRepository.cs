using Domain.Entities.Quizzes;

namespace Application.Repositories.Services.Quizzes;

public interface IQuizHistoryRepository:IAsyncRepository<QuizHistory>,IRepository<QuizHistory>
{
    
}