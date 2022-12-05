using Application.Abstractions.Services.Paging;
using Application.Features.Lessons.Lesson.Commands.CreateLesson;
using Application.Features.Lessons.Lesson.Commands.DeleteLesson;
using Application.Features.Lessons.Lesson.Commands.UpdateLesson;
using Application.Features.Lessons.Lesson.Models;
using Application.Features.Lessons.Lesson.Queries.GetListLesson;
using AutoMapper;

namespace Application.Features.Lessons.Lesson.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Lessons.Lesson, CreateLessonCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson, CreateLessonCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson, DeleteLessonCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson, DeleteLessonCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson, UpdateLessonCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson, UpdateLessonCommandResponse>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Lessons.Lesson>,LessonListModel>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson,GetListLessonQueryResponse>()
            .ForMember(c=>c.SubCategoryName,opt=>opt.MapFrom(c=>c.SubCategory.Name))
            .ForMember(c=>c.Subjects,opt=>opt.MapFrom(c=>c.LessonSubjects)).ReverseMap();
    }
}