using Application.Repositories.Services.Quizzes;
using Domain.Entities.Quizzes;
using Persistence.Contexts;

namespace Persistence.Repositories.Quizzes;

public class QuestionImageRepository:EfRepositoryBase<QuestionImage,BaseDbContext>,IQuestionImageRepository
{
    public QuestionImageRepository(BaseDbContext context) : base(context)
    {
    }
}