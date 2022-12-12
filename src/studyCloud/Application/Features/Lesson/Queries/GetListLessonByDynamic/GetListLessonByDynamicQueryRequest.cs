using Application.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Lesson.Queries.GetListLessonByDynamic;

public class GetListLessonByDynamicQueryRequest:IRequest<List<GetListLessonByDynamicQueryResponse>>
{
    public Dynamic Dynamic { get; set; }
}