namespace Application.Repositories.Services;

public interface IQuery<T>
{
    IQueryable<T> Query();
}