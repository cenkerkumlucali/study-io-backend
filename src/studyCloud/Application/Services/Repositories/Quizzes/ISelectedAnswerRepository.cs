using Domain.Entities.Quizzes;

namespace Application.Services.Repositories.Quizzes;

public interface ISelectedAnswerRepository:IAsyncRepository<SelectedAnswer>,IRepository<SelectedAnswer>
{
    
}