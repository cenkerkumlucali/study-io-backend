using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.Lessons.Lesson.Commands.UpdateLesson;

public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommandRequest, UpdateLessonCommandResponse>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public UpdateLessonCommandHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<UpdateLessonCommandResponse> Handle(UpdateLessonCommandRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Lessons.Lesson? lesson = await _lessonRepository.GetAsync(c => c.Id == request.Id);
        Domain.Entities.Lessons.Lesson? mappedLesson = _mapper.Map(request, lesson);
        UpdateLessonCommandResponse? mappedResponse = _mapper.Map<UpdateLessonCommandResponse>(mappedLesson);
        return mappedResponse;
    }
}