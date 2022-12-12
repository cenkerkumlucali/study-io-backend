using Application.Abstractions.Services.Paging;
using Application.Features.SelectedAnswer.Commands.CreateSelectedAnswer;
using Application.Features.SelectedAnswer.Commands.DeleteSelectedAnswer;
using Application.Features.SelectedAnswer.Commands.UpdateSelectedAnswer;
using Application.Features.SelectedAnswer.Models;
using Application.Features.SelectedAnswer.Queries.GetByIdSelectedAnswer;
using Application.Features.SelectedAnswer.Queries.GetListSelectedAnswer;
using AutoMapper;

namespace Application.Features.SelectedAnswer.Profiles;

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