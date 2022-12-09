namespace Application.Abstractions.Services.Paging;

public interface IPaginate<T>
{
    int From { get; }
    int Index { get; }
    int Size { get; }
    int Count { get; }
    int Pages { get; }
    IList<T> Items { get; set; }
    bool HasPrevious { get; }
    bool HasNext { get; }
}