using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.Lesson.Queries.GetListBySubCategory;

public class GetListBySubCategoryQueryHandler:IRequestHandler<GetListBySubCategoryQueryRequest,List<GetListBySubCategoryQueryResponse>>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public GetListBySubCategoryQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListBySubCategoryQueryResponse>> Handle(GetListBySubCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Lessons.Lesson> lessons = await _lessonRepository.GetAllAsync(c=>c.SubCategoryId == request.SubCategoryId);
        List<GetListBySubCategoryQueryResponse>? mappedLessons = _mapper.Map<List<GetListBySubCategoryQueryResponse>>(lessons);
        return mappedLessons;
    }
}