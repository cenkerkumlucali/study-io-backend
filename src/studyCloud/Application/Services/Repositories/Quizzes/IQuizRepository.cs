using Domain.Entities.Quizzes;

namespace Application.Services.Repositories.Quizzes;

public interface IQuizRepository:IAsyncRepository<Quiz>,IRepository<Quiz>
{
    
}