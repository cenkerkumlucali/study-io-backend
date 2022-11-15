using Application.Services.Repositories.Quizzes;
using Domain.Entities.Quizzes;
using Persistence.Contexts;

namespace Persistence.Repositories.Quizzes;

public class AnswerRepository:EfRepositoryBase<Answer,BaseDbContext>,IAnswerRepository
{
    public AnswerRepository(BaseDbContext context) : base(context)
    {
    }
}