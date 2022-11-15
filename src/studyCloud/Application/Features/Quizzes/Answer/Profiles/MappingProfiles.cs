using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.Answer.Commands.CreateAnswer;
using Application.Features.Quizzes.Answer.Commands.DeleteAnswer;
using Application.Features.Quizzes.Answer.Commands.UpdateAnswer;
using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Answer.Models;
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

        CreateMap<IPaginate<Domain.Entities.Quizzes.Answer>, AnswerListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, ListAnswerQueryResponse>()
            .ForMember(c => c.Question, opt => opt.MapFrom(c => c.Question.Text)).ReverseMap();

        CreateMap<Domain.Entities.Quizzes.Answer, GetByIdAnswerQueryResponse>().ReverseMap();
    }
}