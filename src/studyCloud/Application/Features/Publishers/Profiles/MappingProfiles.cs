using Application.Abstractions.Services.Paging;
using Application.Features.Publishers.Commands.CreatePublisher;
using Application.Features.Publishers.Models;
using Application.Features.Publishers.Queries.GetListPublisher;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Publishers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Publisher, CreatePublisherCommandResponse>().ReverseMap();
        CreateMap<Publisher, CreatePublisherCommandRequest>().ReverseMap();
        CreateMap<IPaginate<Publisher>, PublisherListModel>().ReverseMap();
        CreateMap<Publisher, GetListPublisherQueryResponse>()
            .ForMember(c => c.PictureUrl, opt => opt.MapFrom(c => c.PublisherImages.LastOrDefault().Url))
            .ReverseMap();
       
    }
}