using Domain.Entities.Quizzes;

namespace Application.Repositories.Services.Quizzes;

public interface IQuestionRepository:IAsyncRepository<Question>,IRepository<Question>
{
    
}