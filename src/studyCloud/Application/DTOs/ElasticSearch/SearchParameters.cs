namespace Application.DTOs.ElasticSearch;

public class SearchParameters
{
    public string IndexName { get; set; }
    public int From { get; set; } = 0;
    public int Size { get; set; } = 10;
}