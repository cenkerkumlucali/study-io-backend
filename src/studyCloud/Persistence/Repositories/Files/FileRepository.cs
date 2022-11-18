using Application.Repositories.Services.Files;
using Persistence.Contexts;
using File = Domain.Entities.File;

namespace Persistence.Repositories.Files;

public class FileRepository:EfRepositoryBase<File,BaseDbContext>,IFileRepository
{
    public FileRepository(BaseDbContext context) : base(context)
    {
    }
}