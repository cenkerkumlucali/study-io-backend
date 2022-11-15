using Application.Abstractions.Services.Paging;
using Application.Features.Mentions.Commands.CreateMention;
using Application.Features.Mentions.Commands.DeleteMention;
using Application.Features.Mentions.Commands.UpdateMention;
using Application.Features.Mentions.Dtos;
using Application.Features.Mentions.Models;
using AutoMapper;
using Domain.Entities.Mentions;

namespace Application.Features.Mentions.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Mention, CreateMentionCommandResponse>().ReverseMap();
        CreateMap<Mention, CreateMentionCommandRequest>().ReverseMap();
        CreateMap<Mention, DeleteMentionCommandResponse>().ReverseMap();
        CreateMap<Mention, DeleteMentionCommandRequest>().ReverseMap();
        CreateMap<Mention, UpdateMentionCommandResponse>().ReverseMap();
        CreateMap<Mention, UpdateMentionCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Mention>,MentionListModel>().ReverseMap();
        CreateMap<Mention,ListMentionQueryResponse>().ReverseMap();

        CreateMap<Mention, GetByIdMentionQueryResponse>().ReverseMap();
    }
}