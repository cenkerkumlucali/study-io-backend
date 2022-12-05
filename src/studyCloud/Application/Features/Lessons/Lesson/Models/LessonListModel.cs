using Application.Features.Lessons.Lesson.Queries.GetListLesson;

namespace Application.Features.Lessons.Lesson.Models;

public class LessonListModel
{
    public IList<GetListLessonQueryResponse> Items { get; set; }
}