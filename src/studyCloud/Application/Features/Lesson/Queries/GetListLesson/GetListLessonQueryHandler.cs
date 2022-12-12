using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.Lesson.Queries.GetListLesson;

public class GetListLessonQueryHandler:IRequestHandler<GetListLessonQueryRequest,List<GetListLessonQueryResponse>>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public GetListLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListLessonQueryResponse>> Handle(GetListLessonQueryRequest request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Lessons.Lesson> lessons = await _lessonRepository.GetAllAsync(c=>c.SubCategoryId != 21);
        List<GetListLessonQueryResponse>? mappedLessons = _mapper.Map<List<GetListLessonQueryResponse>>(lessons);
        return mappedLessons;
    }
}