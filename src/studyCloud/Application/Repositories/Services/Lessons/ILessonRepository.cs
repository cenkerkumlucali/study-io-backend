using Domain.Entities.Lessons;

namespace Application.Repositories.Services.Lessons;

public interface ILessonRepository:IAsyncRepository<Lesson>,IRepository<Lesson>
{
    
}