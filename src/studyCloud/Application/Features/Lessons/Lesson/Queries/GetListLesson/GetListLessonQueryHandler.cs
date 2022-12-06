using Application.Features.Lessons.LessonSubject.Dtos;
using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Features.Lessons.Lesson.Queries.GetListLesson;

public class GetListLessonQueryHandler : IRequestHandler<GetListLessonQueryRequest,  List<GetListLessonQueryResponse>>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public GetListLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task< List<GetListLessonQueryResponse>> Handle(GetListLessonQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Domain.Entities.Lessons.Lesson> lesson =
            await _lessonRepository.GetAllAsync(
                include: c => c.Include(c => c.SubCategory)
                    .Include(c => c.LessonSubjects)
                    .ThenInclude(c => c.Parent)
                    .Include(c => c.LessonSubjects).ThenInclude(c => c.Children));
        
        lesson = lesson.Where(parent => parent.LessonSubjects.Any(child => child.Parent is null))
            .Select(p => new Domain.Entities.Lessons.Lesson 
            { 
                Name = p.Name,
                SubCategory = p.SubCategory,
                LessonSubjects = p.LessonSubjects.Where(c=>c.ParentId is null).ToList(),
            }).ToList();

        List<GetListLessonQueryResponse>? mappedLesson = _mapper.Map<List<GetListLessonQueryResponse>>(lesson);
        return mappedLesson;
    }
}