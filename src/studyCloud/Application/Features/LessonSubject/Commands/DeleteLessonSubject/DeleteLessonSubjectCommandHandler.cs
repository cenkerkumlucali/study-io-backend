using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.LessonSubject.Commands.DeleteLessonSubject;

public class DeleteLessonSubjectCommandHandler:IRequestHandler<DeleteLessonSubjectCommandRequest,DeleteLessonSubjectCommandResponse>
{
    private readonly ILessonSubjectRepository _lessonSubjectRepository;
    private IMapper _mapper;

    public DeleteLessonSubjectCommandHandler(ILessonSubjectRepository lessonSubjectRepository, IMapper mapper)
    {
        _lessonSubjectRepository = lessonSubjectRepository;
        _mapper = mapper;
    }

    public async Task<DeleteLessonSubjectCommandResponse> Handle(DeleteLessonSubjectCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Lessons.LessonSubject? lessonSubject = await _lessonSubjectRepository.GetAsync(c => c.Id == request.Id);
        Domain.Entities.Lessons.LessonSubject deletedLessonSubject = await _lessonSubjectRepository.DeleteAsync(lessonSubject);
        DeleteLessonSubjectCommandResponse? mappedResponse = _mapper.Map<DeleteLessonSubjectCommandResponse>(deletedLessonSubject);
        return mappedResponse;
    }
}