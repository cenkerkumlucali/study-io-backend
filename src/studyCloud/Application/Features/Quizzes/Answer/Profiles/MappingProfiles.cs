using Application.Features.Quizzes.Answer.Commands.CreateAnswer;
using Application.Features.Quizzes.Answer.Commands.DeleteAnswer;
using Application.Features.Quizzes.Answer.Commands.UpdateAnswer;
using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Answer.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.Answer.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.Answer, CreatedAnswerDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, CreateAnswerCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, DeletedAnswerDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, DeleteAnswerCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, UpdatedAnswerDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer, UpdateAnswerCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.Answer>,AnswerListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.Answer,ListAnswerDto>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.Answer, GetByIdAnswerDto>().ReverseMap();
    }
}