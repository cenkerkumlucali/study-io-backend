using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Lesson.Queries.GetListLessonSubjects;

public class GetListLessonSubjectsQueryHandler : IRequestHandler<GetListLessonSubjectsQueryRequest,  List<GetListLessonSubjectsQueryResponse>>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public GetListLessonSubjectsQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task< List<GetListLessonSubjectsQueryResponse>> Handle(GetListLessonSubjectsQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Domain.Entities.Lessons.Lesson> lesson =
            await _lessonRepository.GetAllAsync(
                include: c => c.Include(c => c.SubCategory)
                    .Include(c => c.LessonSubjects)
                    .ThenInclude(c => c.Parent)
                    .Include(c => c.LessonSubjects).ThenInclude(c => c.Children));
        
        lesson = lesson
            .Select(p => new Domain.Entities.Lessons.Lesson 
            { 
                Name = p.Name,
                SubCategory = p.SubCategory,
                LessonSubjects = p.LessonSubjects.Where(c=>c.ParentId is null).ToList(),
            }).ToList();

        List<GetListLessonSubjectsQueryResponse>? mappedLesson = _mapper.Map<List<GetListLessonSubjectsQueryResponse>>(lesson);
        return mappedLesson;
    }
}