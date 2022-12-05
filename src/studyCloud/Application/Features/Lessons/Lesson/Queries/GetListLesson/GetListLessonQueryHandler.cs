using Application.Abstractions.Services.Paging;
using Application.Features.Lessons.Lesson.Models;
using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Lessons.Lesson.Queries.GetListLesson;

public class GetListLessonQueryHandler : IRequestHandler<GetListLessonQueryRequest, LessonListModel>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public GetListLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<LessonListModel> Handle(GetListLessonQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Lessons.Lesson> lesson =
            await _lessonRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.SubCategory).Include(c => c.LessonSubjects).ThenInclude(c => c.Parent));
        LessonListModel? mappesLesson = _mapper.Map<LessonListModel>(lesson);
        return mappesLesson;
    }
}