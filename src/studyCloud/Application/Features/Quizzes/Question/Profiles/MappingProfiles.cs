using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Question.Commands.CreateQuestion;
using Application.Features.Quizzes.Question.Commands.DeleteQuestion;
using Application.Features.Quizzes.Question.Commands.UpdateQuestion;
using Application.Features.Quizzes.Question.Dtos;
using Application.Features.Quizzes.Question.Models;
using Application.Features.Quizzes.Question.Queries.GetByIdQuestion;
using Application.Features.Quizzes.Question.Queries.GetListByQuizId;
using Application.Features.Quizzes.Question.Queries.GetListQuestion;
using AutoMapper;

namespace Application.Features.Quizzes.Question.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.Question, CreateQuestionCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, CreateQuestionCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, DeleteQuestionCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, DeleteQuestionCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, UpdateQuestionCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, UpdateQuestionCommandRequest>().ReverseMap();
       

        CreateMap<IPaginate<Domain.Entities.Quizzes.Question>, GetByQuizIdModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, GetListByQuizIdQueryResponse>()
            .ForMember(c => c.Answers, opt => opt.MapFrom(c => c.Answers))
            .ForMember(c => c.ImageUrl, opt => opt.MapFrom(c => c.QuestionImages.FirstOrDefault().Url)).ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Quizzes.Question>, QuestionListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, ListQuestionQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Question, GetByIdQuestionQueryResponse>().ReverseMap();
    }
}