using Domain.Entities.Quizzes;

namespace Application.Services.Repositories.Quizzes;

public interface IQuestionRepository:IAsyncRepository<Question>,IRepository<Question>
{
    
}