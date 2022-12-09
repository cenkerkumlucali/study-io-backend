using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Answer.Commands.CreateAnswer;
using Application.Features.Quizzes.Answer.Commands.DeleteAnswer;
using Application.Features.Quizzes.Answer.Commands.UpdateAnswer;
using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Answer.Models;
using Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;
using Application.Features.Quizzes.Answer.Queries.GetListAnswer;
using AutoMapper;

namespace Application.Features.Quizzes.Answer.Profiles;

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