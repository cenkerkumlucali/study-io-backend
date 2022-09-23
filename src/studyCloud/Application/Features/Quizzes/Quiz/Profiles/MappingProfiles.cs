using Application.Features.Quizzes.Quiz.Commands.CreateQuiz;
using Application.Features.Quizzes.Quiz.Commands.DeleteQuiz;
using Application.Features.Quizzes.Quiz.Commands.UpdateQuiz;
using Application.Features.Quizzes.Quiz.Dtos;
using Application.Features.Quizzes.Quiz.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.Quiz.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.Quiz, CreatedQuizDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, CreateQuizCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, DeletedQuizDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, DeleteQuizCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, UpdatedQuizDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz, UpdateQuizCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.Quiz>,QuizListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz,ListQuizDto>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.Quiz, GetByIdQuizDto>().ReverseMap();
    }
}