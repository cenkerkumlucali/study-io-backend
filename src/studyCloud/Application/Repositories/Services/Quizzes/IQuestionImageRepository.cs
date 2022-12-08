using Domain.Entities.Quizzes;

namespace Application.Repositories.Services.Quizzes;

public interface IQuestionImageRepository:IAsyncRepository<QuestionImage>,IRepository<QuestionImage>
{
    
}