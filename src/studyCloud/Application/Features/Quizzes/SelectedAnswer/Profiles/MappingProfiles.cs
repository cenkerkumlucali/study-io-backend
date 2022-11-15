using Application.Abstractions.Services.Paging;
using Application.Features.Quizzes.SelectedAnswer.Commands.CreateSelectedAnswer;
using Application.Features.Quizzes.SelectedAnswer.Commands.DeleteSelectedAnswer;
using Application.Features.Quizzes.SelectedAnswer.Commands.UpdateSelectedAnswer;
using Application.Features.Quizzes.SelectedAnswer.Dtos;
using Application.Features.Quizzes.SelectedAnswer.Models;
using AutoMapper;

namespace Application.Features.Quizzes.SelectedAnswer.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, CreateSelectedAnswerCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, CreateSelectedAnswerCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, DeleteSelectedAnswerCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, DeleteSelectedAnswerCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, UpdateSelectedAnswerCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, UpdateSelectedAnswerCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.SelectedAnswer>,SelectedAnswerListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer,ListSelectedAnswerQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, GetByIdSelectedAnswerQueryResponse>().ReverseMap();
    }
}