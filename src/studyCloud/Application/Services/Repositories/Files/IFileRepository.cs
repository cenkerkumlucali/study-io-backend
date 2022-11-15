using File = Domain.Entities.File.File;

namespace Application.Services.Repositories.Files;

public interface IFileRepository:IAsyncRepository<File>,IRepository<File>
{
    
}