using Application.Services.Repositories.Quizzes;
using Domain.Entities.Quizzes;
using Persistence.Contexts;

namespace Persistence.Repositories.Quizzes;

public class QuizHistoryRepository:EfRepositoryBase<QuizHistory,BaseDbContext>,IQuizHistoryRepository
{
    public QuizHistoryRepository(BaseDbContext context) : base(context)
    {
    }
}