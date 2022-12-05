using Application.Repositories.Services.Lessons;
using Domain.Entities.Lessons;
using Persistence.Contexts;

namespace Persistence.Repositories.Lessons;

public class LessonRepository:EfRepositoryBase<Lesson,BaseDbContext>,ILessonRepository
{
    public LessonRepository(BaseDbContext context) : base(context)
    {
    }
}