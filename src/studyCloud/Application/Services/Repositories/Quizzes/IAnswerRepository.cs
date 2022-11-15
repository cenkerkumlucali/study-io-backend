using Domain.Entities.Quizzes;

namespace Application.Services.Repositories.Quizzes;

public interface IAnswerRepository:IAsyncRepository<Answer>,IRepository<Answer>
{
    
}