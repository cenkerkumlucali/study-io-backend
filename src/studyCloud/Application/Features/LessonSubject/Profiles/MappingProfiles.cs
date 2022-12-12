using Application.Features.LessonSubject.Commands.CreateLessonSubject;
using Application.Features.LessonSubject.Commands.DeleteLessonSubject;
using Application.Features.LessonSubject.Commands.UpdateLessonSubject;
using Application.Features.LessonSubject.Dtos;
using AutoMapper;

namespace Application.Features.LessonSubject.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Lessons.LessonSubject, LessonSubjectDto>()
            .ForMember(c => c.Children, c => c.MapFrom(c => c.Children)).ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, CreateLessonSubjectCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, CreateLessonSubjectCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, DeleteLessonSubjectCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, DeleteLessonSubjectCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, UpdateLessonSubjectCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, UpdateLessonSubjectCommandResponse>().ReverseMap();
    }
}