using Application.Repositories.Services.Alarm;
using Persistence.Contexts;

namespace Persistence.Repositories.Alarm;

public class AlarmRepository:EfRepositoryBase<Domain.Entities.Alarm,BaseDbContext>,IAlarmRepository
{
    public AlarmRepository(BaseDbContext context) : base(context)
    {
    }
}