namespace Application.DTOs.ElasticSearch;

public interface IElasticSearchResult
{
    bool Success { get; }
    string Message { get; }
}