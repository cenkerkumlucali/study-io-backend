using Application.Abstractions.Services.Paging;
using Application.Features.FlashCards.Commands.CreateFlashCard;
using Application.Features.FlashCards.Commands.DeleteFlashCard;
using Application.Features.FlashCards.Commands.UpdateFlashCard;
using Application.Features.FlashCards.Models;
using Application.Features.FlashCards.Queries.GetListByLessonSubjectId;
using AutoMapper;

namespace Application.Features.FlashCards.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.FlashCard, CreateFlashCardCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.FlashCard, CreateFlashCardCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.FlashCard, DeleteFlashCardCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.FlashCard, DeleteFlashCardCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.FlashCard, UpdateFlashCardCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.FlashCard, UpdateFlashCardCommandRequest>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.FlashCard>, GetByLessonSubjectIdListModel>().ReverseMap();
        CreateMap<Domain.Entities.FlashCard, GetListByLessonSubjectIdQueryResponse>().ReverseMap();

    }
}