using Application.Features.Categories.Dtos;
using Application.Features.Lesson.Commands.CreateLesson;
using Application.Features.Lesson.Commands.DeleteLesson;
using Application.Features.Lesson.Commands.UpdateLesson;
using Application.Features.Lesson.Dtos;
using Application.Features.Lesson.Queries.GetLessonById;
using Application.Features.Lesson.Queries.GetListBySubCategory;
using Application.Features.Lesson.Queries.GetListLesson;
using Application.Features.Lesson.Queries.GetListLessonByDynamic;
using AutoMapper;
using Domain.Entities.Categories;

namespace Application.Features.Lesson.Profiles;

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
        CreateMap<Domain.Entities.Lessons.Lesson, LessonDto>().ReverseMap();
        CreateMap<Category, GetListLessonQueryResponse>().ReverseMap();

        CreateMap<Category, GetListLessonQueryResponse>()
            .ForMember(c => c.Id, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
            .ForMember(c => c.SubCategories, opt => opt.MapFrom(c => c.SubCategories))
            .ForMember(c => c.Lessons, opt => opt.MapFrom(c => c.Lessons))
            .ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson, GetListBySubCategoryQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Lessons.Lesson, GetListLessonByDynamicQueryResponse>().ReverseMap();


        CreateMap<Domain.Entities.Lessons.Lesson, GetByIdLessonQueryResponse>()
            .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.Name))
            .ForMember(c => c.SubCategoryName, opt => opt.MapFrom(c => c.SubCategory.Name))
            .ForMember(c => c.Subjects, opt => opt.MapFrom(c => c.LessonSubjects)).ReverseMap();
    }
}