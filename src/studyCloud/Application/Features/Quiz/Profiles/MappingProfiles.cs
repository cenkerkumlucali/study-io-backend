using Application.Abstractions.Services.Paging;
using Application.Features.Quiz.Commands.CreateQuiz;
using Application.Features.Quiz.Commands.DeleteQuiz;
using Application.Features.Quiz.Commands.UpdateQuiz;
using Application.Features.Quiz.Dtos;
using Application.Features.Quiz.Models;
using Application.Features.Quiz.Queries.GetByPublisherId;
using Application.Features.Quiz.Queries.GetListQuiz;
using AutoMapper;

namespace Application.Features.Quiz.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.Quiz, CreateQuizCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, CreateQuizCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, DeleteQuizCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, DeleteQuizCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, UpdateQuizCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, UpdateQuizCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, PublisherQuizDto>() 
            .ForMember(c => c.QuizId, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.LessonName, opt => opt.MapFrom(c => c.Lesson.Name))
            .ForMember(c => c.QuizName, opt => opt.MapFrom(c => c.Name))
            .ForMember(c => c.SubCategoryName, opt => opt.MapFrom(c => c.SubCategory.Name))
            .ForMember(c => c.Difficulty,  opt => opt.MapFrom(c => Math.Ceiling(c.Questions.Average(c => (decimal)c.Difficulty))))            .ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.Quiz>,QuizListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, ListQuizQueryResponse>()
            .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.SubCategory.Category.Name))
            .ForMember(c => c.SubCategoryName, opt => opt.MapFrom(c => c.SubCategory.Name))
            .ForMember(c => c.LessonName, opt => opt.MapFrom(c => c.Lesson.Name))
            .ForMember(c => c.QuestionCount, opt => opt.MapFrom(c => c.Questions.Count))
            .ForMember(c => c.Difficulty,  opt => opt.MapFrom(c => Math.Ceiling(c.Questions.Average(c => (decimal)c.Difficulty))))
            .ReverseMap();
        
        CreateMap<Domain.Entities.Quizzes.Quiz, GetByPublisherIdQueryResponse>()
            .ForMember(c=>c.PublisherId, opt=>opt.MapFrom(c=>c.Publisher.Id))
            .ForMember(c=>c.PublisherName, opt=>opt.MapFrom(c=>c.Publisher.Name))
            .ForMember(c => c.PublisherPictureUrl, opt => opt.MapFrom(c => c.Publisher.PublisherImages.LastOrDefault().Url))
            .ForMember(c => c.Quizzes, opt => opt.MapFrom(c => c.Publisher.Quizzes))
            .ReverseMap();

    }
}