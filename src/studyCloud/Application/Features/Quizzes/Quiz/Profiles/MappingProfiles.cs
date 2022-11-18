using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Quiz.Commands.CreateQuiz;
using Application.Features.Quizzes.Quiz.Commands.DeleteQuiz;
using Application.Features.Quizzes.Quiz.Commands.UpdateQuiz;
using Application.Features.Quizzes.Quiz.Models;
using Application.Features.Quizzes.Quiz.Queries.GetByIdQuiz;
using Application.Features.Quizzes.Quiz.Queries.GetListQuiz;
using AutoMapper;

namespace Application.Features.Quizzes.Quiz.Profiles;

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
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.Quiz>,QuizListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Quiz,ListQuizQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.Quiz, GetByIdQuizQueryResponse>().ReverseMap();
    }
}