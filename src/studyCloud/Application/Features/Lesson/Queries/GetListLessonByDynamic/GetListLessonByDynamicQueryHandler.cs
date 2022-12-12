using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.Lesson.Queries.GetListLessonByDynamic;

public class GetListLessonByDynamicQueryHandler:IRequestHandler<GetListLessonByDynamicQueryRequest,List<GetListLessonByDynamicQueryResponse>>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public GetListLessonByDynamicQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListLessonByDynamicQueryResponse>> Handle(GetListLessonByDynamicQueryRequest request, CancellationToken cancellationToken)
    {
       List<Domain.Entities.Lessons.Lesson> lessons = await _lessonRepository.GetAllByDynamicAsync(dynamic: request.Dynamic);
       List<GetListLessonByDynamicQueryResponse> mappedLessons = _mapper.Map<List<GetListLessonByDynamicQueryResponse>>(lessons);
        return mappedLessons;
    }
}