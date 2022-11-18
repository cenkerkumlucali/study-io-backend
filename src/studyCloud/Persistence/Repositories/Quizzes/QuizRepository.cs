using Application.Repositories.Services.Quizzes;
using Domain.Entities.Quizzes;
using Persistence.Contexts;

namespace Persistence.Repositories.Quizzes;

public class QuizRepository:EfRepositoryBase<Quiz,BaseDbContext>,IQuizRepository
{
    public QuizRepository(BaseDbContext context) : base(context)
    {
    }
}