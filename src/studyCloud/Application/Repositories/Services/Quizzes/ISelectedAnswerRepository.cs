using Domain.Entities.Quizzes;

namespace Application.Repositories.Services.Quizzes;

public interface ISelectedAnswerRepository:IAsyncRepository<SelectedAnswer>,IRepository<SelectedAnswer>
{
    
}