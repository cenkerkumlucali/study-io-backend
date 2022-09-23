using Application.Features.Quizzes.SelectedAnswer.Commands.CreateSelectedAnswer;
using Application.Features.Quizzes.SelectedAnswer.Commands.DeleteSelectedAnswer;
using Application.Features.Quizzes.SelectedAnswer.Commands.UpdateSelectedAnswer;
using Application.Features.Quizzes.SelectedAnswer.Dtos;
using Application.Features.Quizzes.SelectedAnswer.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.SelectedAnswer.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, CreatedSelectedAnswerDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, CreateSelectedAnswerCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, DeletedSelectedAnswerDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, DeleteSelectedAnswerCommand>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, UpdatedSelectedAnswerDto>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, UpdateSelectedAnswerCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Quizzes.SelectedAnswer>,SelectedAnswerListModel>().ReverseMap();
        CreateMap<Domain.Entities.Quizzes.SelectedAnswer,ListSelectedAnswerDto>().ReverseMap();

        CreateMap<Domain.Entities.Quizzes.SelectedAnswer, GetByIdSelectedAnswerDto>().ReverseMap();
    }
}