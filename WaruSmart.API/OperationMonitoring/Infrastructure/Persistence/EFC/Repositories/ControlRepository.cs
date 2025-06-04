using Microsoft.EntityFrameworkCore;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.OperationMonitoring.Infrastructure.Persistence.EFC.Repositories;

public class ControlRepository : BaseRepository<Control>, IControlRepository
{
    public ControlRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Control>> FindBySowingIdAsync(int sowingId)
    {
        return await Context.Set<Control>()
            .Where(c => c.SowingId == sowingId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Control>> FindByIdAndSowingIdAsync(int id, int sowingId)
    {
        return await Context.Set<Control>()
            .Where(c => c.Id == id && c.SowingId == sowingId)
            .ToListAsync();
    }

    public void Delete(Control control)
    {
        Context.Set<Control>().Remove(control);
    }
}