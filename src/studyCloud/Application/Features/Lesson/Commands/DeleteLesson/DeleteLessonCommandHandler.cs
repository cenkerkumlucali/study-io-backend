using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.Lesson.Commands.DeleteLesson;

public class DeleteLessonCommandHandler:IRequestHandler<DeleteLessonCommandRequest,DeleteLessonCommandResponse>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public DeleteLessonCommandHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<DeleteLessonCommandResponse> Handle(DeleteLessonCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Lessons.Lesson? deleteLesson = await _lessonRepository.GetAsync(c=>c.Id == request.Id);
        Domain.Entities.Lessons.Lesson deletedLesson = await _lessonRepository.DeleteAsync(deleteLesson);
        DeleteLessonCommandResponse? mappedLesson = _mapper.Map<DeleteLessonCommandResponse>(deletedLesson);
        return mappedLesson;
    }
}