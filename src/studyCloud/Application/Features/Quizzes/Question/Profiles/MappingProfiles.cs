using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Question.Commands.CreateQuestion;
using Application.Features.Quizzes.Question.Commands.DeleteQuestion;
using Application.Features.Quizzes.Question.Commands.UpdateQuestion;
using Application.Features.Quizzes.Question.Dtos;
using Application.Features.Quizzes.Question.Models;
using AutoMapper;

namespace Application.Features.Quizzes.Question.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.Question, CreateQuestionCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, CreateQuestionCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, DeleteQuestionCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, DeleteQuestionCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, UpdateQuestionCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, UpdateQuestionCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.Question>,QuestionListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question,ListQuestionQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.Question, GetByIdQuestionQueryResponse>().ReverseMap();
    }
}