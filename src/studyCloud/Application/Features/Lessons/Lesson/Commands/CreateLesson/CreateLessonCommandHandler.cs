using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.Lessons.Lesson.Commands.CreateLesson;

public class CreateLessonCommandHandler:IRequestHandler<CreateLessonCommandRequest,CreateLessonCommandResponse>
{
    private readonly ILessonRepository _lessonRepository;
    private IMapper _mapper;

    public CreateLessonCommandHandler(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<CreateLessonCommandResponse> Handle(CreateLessonCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Lessons.Lesson mappedLesson = _mapper.Map<Domain.Entities.Lessons.Lesson>(request);
        Domain.Entities.Lessons.Lesson createdLesson = await _lessonRepository.AddAsync(mappedLesson);
        CreateLessonCommandResponse? mappedCreatedLesson = _mapper.Map<CreateLessonCommandResponse>(createdLesson);
        return mappedCreatedLesson;
    }
}