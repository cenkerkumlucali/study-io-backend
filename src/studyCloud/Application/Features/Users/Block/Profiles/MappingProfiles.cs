using Application.Features.Users.Block.Commands.CreateBlock;
using Application.Features.Users.Block.Commands.DeleteBlock;
using AutoMapper;

namespace Application.Features.Users.Block.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.Block, CreateBlockCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.Block, CreateBlockCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.Block, DeleteBlockCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.Block, DeleteBlockCommandResponse>().ReverseMap();
    }
}