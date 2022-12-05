using Application.Features.Lessons.LessonSubject.Commands.CreateLessonSubject;
using Application.Features.Lessons.LessonSubject.Commands.DeleteLessonSubject;
using Application.Features.Lessons.LessonSubject.Commands.UpdateLessonSubject;
using Application.Features.Lessons.LessonSubject.Dtos;
using AutoMapper;

namespace Application.Features.Lessons.LessonSubject.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Lessons.LessonSubject, LessonSubjectDto>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, CreateLessonSubjectCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, CreateLessonSubjectCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, DeleteLessonSubjectCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, DeleteLessonSubjectCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, UpdateLessonSubjectCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.LessonSubject, UpdateLessonSubjectCommandResponse>().ReverseMap();
    }
}