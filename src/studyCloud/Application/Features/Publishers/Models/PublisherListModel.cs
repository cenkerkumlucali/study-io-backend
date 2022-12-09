using Application.DTOs.Paging;
using Application.Features.Publishers.Queries.GetListPublisher;

namespace Application.Features.Publishers.Models;

public class PublisherListModel:BasePageableModel
{
    public IList<GetListPublisherQueryResponse> Items { get; set; }
}