using Application.Abstractions.Services.Paging;
using Application.Features.FlashCard.Commands.CreateFlashCard;
using Application.Features.FlashCard.Commands.DeleteFlashCard;
using Application.Features.FlashCard.Commands.UpdateFlashCard;
using Application.Features.FlashCard.Models;
using Application.Features.FlashCard.Queries.GetListByLessonSubjectId;
using AutoMapper;

namespace Application.Features.FlashCard.Profiles;

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