using Application.Repositories.Services.Lessons;
using AutoMapper;
using MediatR;

namespace Application.Features.LessonSubject.Commands.CreateLessonSubject;

public class CreateLessonSubjectCommandHandler:IRequestHandler<CreateLessonSubjectCommandRequest,CreateLessonSubjectCommandResponse>
{
    private readonly ILessonSubjectRepository _lessonSubjectRepository;
    private IMapper _mapper;

    public CreateLessonSubjectCommandHandler(ILessonSubjectRepository lessonSubjectRepository, IMapper mapper)
    {
        _lessonSubjectRepository = lessonSubjectRepository;
        _mapper = mapper;
    }

    public async Task<CreateLessonSubjectCommandResponse> Handle(CreateLessonSubjectCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Lessons.LessonSubject mappedLessonSubject = _mapper.Map<Domain.Entities.Lessons.LessonSubject>(request);
        Domain.Entities.Lessons.LessonSubject createdLessonSubject = await _lessonSubjectRepository.AddAsync(mappedLessonSubject);
        CreateLessonSubjectCommandResponse? mappedResponse = _mapper.Map<CreateLessonSubjectCommandResponse>(createdLessonSubject);
        return mappedResponse;
    }
}