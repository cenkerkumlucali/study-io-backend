using Nest;

namespace Application.DTOs.ElasticSearch;

public class ElasticSearchModel
{
    public Id ElasticId { get; set; }
    public string IndexName { get; set; }
}