using Application.Services.Repositories.Quizzes;
using Core.Persistence.Repositories;
using Domain.Entities.Quizzes;
using Persistence.Contexts;

namespace Persistence.Repositories.Quizzes;

public class SelectedAnswerRepository:EfRepositoryBase<SelectedAnswer,BaseDbContext>,ISelectedAnswerRepository
{
    public SelectedAnswerRepository(BaseDbContext context) : base(context)
    {
    }
}