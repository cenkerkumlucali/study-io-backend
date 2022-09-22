using Application.Features.Mentions.Commands.CreateMention;
using Application.Features.Mentions.Commands.DeleteMention;
using Application.Features.Mentions.Commands.UpdateMention;
using Application.Features.Mentions.Dtos;
using Application.Features.Mentions.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Mentions;

namespace Application.Features.Mentions.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Mention, CreatedMentionDto>().ReverseMap();
        CreateMap<Mention, CreateMentionCommand>().ReverseMap();
        CreateMap<Mention, DeletedMentionDto>().ReverseMap();
        CreateMap<Mention, DeleteMentionCommand>().ReverseMap();
        CreateMap<Mention, UpdatedMentionDto>().ReverseMap();
        CreateMap<Mention, UpdateMentionCommand>().ReverseMap();
        
        CreateMap<IPaginate<Mention>,MentionListModel>().ReverseMap();
        CreateMap<Mention,ListMentionDto>().ReverseMap();

        CreateMap<Mention, GetByIdMentionDto>().ReverseMap();
    }
}