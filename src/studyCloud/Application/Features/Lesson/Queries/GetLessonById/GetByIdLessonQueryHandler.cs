using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lesson.Queries.GetLessonById;

public class GetByIdLessonQueryHandler:IRequestHandler<GetByIdLessonQueryRequest,List<GetByIdLessonQueryResponse>>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public GetByIdLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<List<GetByIdLessonQueryResponse>> Handle(GetByIdLessonQueryRequest request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Lessons.Lesson> lesson = await _lessonRepository.GetAllAsync(c => c.Id == request.Id,
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
        List<GetByIdLessonQueryResponse>? mappedLesson = _mapper.Map<List<GetByIdLessonQueryResponse>>(lesson);
        return mappedLesson;
    }
}