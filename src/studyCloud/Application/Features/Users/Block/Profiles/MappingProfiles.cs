using Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;
using Application.Features.Users.Block.Commands.CreateBlock;
using Application.Features.Users.Block.Commands.DeleteBlock;
using Application.Features.Users.Block.Queries.GetByUserId;
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
        CreateMap<Domain.Entities.Users.Block, GetByIdAnswerQueryRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.Block, GetByUserIdQueryResponse>()
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.Target.FirstName + " " + c.Target.LastName))
            .ForMember(c => c.UserName, c => c.MapFrom(c => c.Target.UserName))
            .ForMember(c => c.PictureUrl, c => c.MapFrom(c => c.Target.UserImageFiles.First().Url))
            .ReverseMap();
    }
}