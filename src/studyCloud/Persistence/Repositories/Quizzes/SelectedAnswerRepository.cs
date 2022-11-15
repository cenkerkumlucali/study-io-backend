using Application.Services.Repositories.Quizzes;
using Domain.Entities.Quizzes;
using Persistence.Contexts;

namespace Persistence.Repositories.Quizzes;

public class SelectedAnswerRepository:EfRepositoryBase<SelectedAnswer,BaseDbContext>,ISelectedAnswerRepository
{
    public SelectedAnswerRepository(BaseDbContext context) : base(context)
    {
    }
}