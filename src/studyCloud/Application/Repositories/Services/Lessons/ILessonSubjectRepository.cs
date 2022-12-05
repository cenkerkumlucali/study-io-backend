using Domain.Entities.Lessons;

namespace Application.Repositories.Services.Lessons;

public interface ILessonSubjectRepository:IAsyncRepository<LessonSubject>,IRepository<LessonSubject>
{
    
}