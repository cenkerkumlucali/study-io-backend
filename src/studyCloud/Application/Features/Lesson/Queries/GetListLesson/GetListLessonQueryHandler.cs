using Application.Abstractions.Services;
using AutoMapper;
using Domain.Entities.Categories;
using MediatR;

namespace Application.Features.Lesson.Queries.GetListLesson;

public class GetListLessonQueryHandler : IRequestHandler<GetListLessonQueryRequest, List<GetListLessonQueryResponse>>
{
    private readonly ICategoryService _categoryService;
    private IMapper _mapper;

    public GetListLessonQueryHandler(IMapper mapper, ICategoryService categoryService)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public async Task<List<GetListLessonQueryResponse>> Handle(GetListLessonQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Category> lesson = await _categoryService.GetListAsync();

        List<GetListLessonQueryResponse>? mappedLessons = _mapper.Map<List<GetListLessonQueryResponse>>(lesson);
        return mappedLessons;
    }
}