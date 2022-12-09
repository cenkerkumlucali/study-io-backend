using Application.Features.Publishers.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Publishers.Queries.GetListPublisher;

public class GetListPublisherQueryRequest:IRequest<PublisherListModel>
{
    public PageRequest PageRequest { get; set; }
}