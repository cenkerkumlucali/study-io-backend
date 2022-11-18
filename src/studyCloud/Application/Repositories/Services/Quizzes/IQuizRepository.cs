using Domain.Entities.Quizzes;

namespace Application.Repositories.Services.Quizzes;

public interface IQuizRepository:IAsyncRepository<Quiz>,IRepository<Quiz>
{
    
}