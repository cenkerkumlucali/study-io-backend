using Application.Repositories.Services.Lessons;
using Domain.Entities.Lessons;
using Persistence.Contexts;

namespace Persistence.Repositories.Lessons;

public class LessonSubjectRepository:EfRepositoryBase<LessonSubject,BaseDbContext>,ILessonSubjectRepository
{
    public LessonSubjectRepository(BaseDbContext context) : base(context)
    {
    }
}