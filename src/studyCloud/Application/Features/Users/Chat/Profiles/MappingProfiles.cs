using Application.Features.Users.Chat.Commands.SendMessage;
using Application.Features.Users.Chat.Dtos;
using AutoMapper;

namespace Application.Features.Users.Chat.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.Chat, SendMessageCommandRequest>().ReverseMap();
        CreateMap<SendMessageCommandRequest, IncommingChatMessage>().ReverseMap();
        CreateMap<OutgoingChatMessage, SendMessageCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.Chat, SendMessageCommandResponse>()
            .ForMember(c=>c.Id,opt=>opt.MapFrom(c=>c.Id))
            .ForMember(c=>c.Message,opt=>opt.MapFrom(c=>c.Message))
            .ForMember(c=>c.FromId,opt=>opt.MapFrom(c=>c.From.Id))
            .ForMember(c=>c.FromUserName,opt=>opt.MapFrom(c=>c.From.UserName))
            .ForMember(c=>c.ToId,opt=>opt.MapFrom(c=>c.To.Id))
            .ForMember(c=>c.ToUserName,opt=>opt.MapFrom(c=>c.To.UserName))
            .ForMember(c=>c.CreatedAt,opt=>opt.MapFrom(c=>c.CreatedDate))
            .ForMember(c=>c.UpdatedAt,opt=>opt.MapFrom(c=>c.UpdatedDate))
            .ReverseMap();
       
    }
}