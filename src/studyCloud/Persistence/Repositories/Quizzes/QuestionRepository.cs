using Application.Services.Repositories.Quizzes;
using Domain.Entities.Quizzes;
using Persistence.Contexts;

namespace Persistence.Repositories.Quizzes;

public class QuestionRepository:EfRepositoryBase<Question,BaseDbContext>,IQuestionRepository
{
    public QuestionRepository(BaseDbContext context) : base(context)
    {
    }
}