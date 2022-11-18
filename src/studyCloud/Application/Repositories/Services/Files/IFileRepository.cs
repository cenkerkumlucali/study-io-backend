using File = Domain.Entities.File;

namespace Application.Repositories.Services.Files;

public interface IFileRepository:IAsyncRepository<File>,IRepository<File>
{
    
}