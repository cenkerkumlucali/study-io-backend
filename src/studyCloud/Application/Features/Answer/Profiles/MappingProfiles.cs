using Application.Abstractions.Services.Paging;
using Application.Features.Answer.Commands.CreateAnswer;
using Application.Features.Answer.Commands.DeleteAnswer;
using Application.Features.Answer.Commands.UpdateAnswer;
using Application.Features.Answer.Dtos;
using Application.Features.Answer.Models;
using Application.Features.Answer.Queries.GetByIdAnswer;
using Application.Features.Answer.Queries.GetListAnswer;
using AutoMapper;

namespace Application.Features.Answer.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.Answer, CreateAnswerCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, CreateAnswerCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, DeleteAnswerCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, DeleteAnswerCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, UpdatedAnswerCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, UpdateAnswerCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, AnswerDto>()
            .ForMember(c => c.content, opt => opt.MapFrom(c => c.Content))
            .ForMember(c => c.isCorrect, opt => opt.MapFrom(c => c.IsCorrect))
            .ForMember(c => c.questionId, opt => opt.MapFrom(c => c.QuestionId))
            .ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Quizzes.Answer>, AnswerListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, ListAnswerQueryResponse>()
            .ForMember(c => c.QuestionUrl, opt => opt.MapFrom(c => c.Question.QuestionImages.FirstOrDefault().Url)).ReverseMap();

        CreateMap<Domain.Entities.Quizzes.Answer, GetByIdAnswerQueryResponse>().ReverseMap();
    }
}