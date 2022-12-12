using Application.Abstractions.Services.Paging;
using Application.Features.Question.Commands.CreateQuestion;
using Application.Features.Question.Commands.DeleteQuestion;
using Application.Features.Question.Commands.UpdateQuestion;
using Application.Features.Question.Models;
using Application.Features.Question.Queries.GetByIdQuestion;
using Application.Features.Question.Queries.GetListByQuizId;
using Application.Features.Question.Queries.GetListQuestion;
using AutoMapper;

namespace Application.Features.Question.Profiles;

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