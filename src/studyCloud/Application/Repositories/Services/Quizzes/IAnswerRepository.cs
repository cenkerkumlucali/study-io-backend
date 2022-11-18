using Domain.Entities.Quizzes;

namespace Application.Repositories.Services.Quizzes;

public interface IAnswerRepository:IAsyncRepository<Answer>,IRepository<Answer>
{
    
}