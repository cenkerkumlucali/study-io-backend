using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.LessonSubject.Commands.UpdateLessonSubject;

public class UpdateLessonSubjectCommandHandler:IRequestHandler<UpdateLessonSubjectCommandRequest,UpdateLessonSubjectCommandResponse>
{
    private readonly ILessonSubjectRepository _lessonSubjectRepository;
    private IMapper _mapper;

    public UpdateLessonSubjectCommandHandler(ILessonSubjectRepository lessonSubjectRepository, IMapper mapper)
    {
        _lessonSubjectRepository = lessonSubjectRepository;
        _mapper = mapper;
    }

    public async Task<UpdateLessonSubjectCommandResponse> Handle(UpdateLessonSubjectCommandRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Lessons.LessonSubject? lesson = await _lessonSubjectRepository.GetAsync(c => c.Id == request.Id);
        Domain.Entities.Lessons.LessonSubject? mappedLesson = _mapper.Map(request, lesson);
        UpdateLessonSubjectCommandResponse? mappedResponse = _mapper.Map<UpdateLessonSubjectCommandResponse>(mappedLesson);
        return mappedResponse;
    }
}