using Application.Features.Quizzes.Question.Commands.CreateQuestion;
using Application.Features.Quizzes.Question.Commands.DeleteQuestion;
using Application.Features.Quizzes.Question.Commands.UpdateQuestion;
using Application.Features.Quizzes.Question.Dtos;
using Application.Features.Quizzes.Question.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.Question.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.Question, CreatedQuestionDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, CreateQuestionCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, DeletedQuestionDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, DeleteQuestionCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, UpdatedQuestionDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, UpdateQuestionCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.Question>,QuestionListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question,ListQuestionDto>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.Question, GetByIdQuestionDto>().ReverseMap();
    }
}