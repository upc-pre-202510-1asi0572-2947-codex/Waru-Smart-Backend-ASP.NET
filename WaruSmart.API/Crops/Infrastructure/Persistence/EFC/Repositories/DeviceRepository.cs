using Microsoft.EntityFrameworkCore;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class DeviceRepository(AppDbContext context) : BaseRepository<Device>(context), IDeviceRepository
{
    public async Task<IEnumerable<Device>> FindBySowingIdAsync(int sowingId)
    {
        return await Context.Set<Device>()
            .Include(d => d.Sowing)
            .Where(d => d.SowingId == sowingId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Device>> FindAllAsync()
    {
        return await Context.Set<Device>()
            .Include(d => d.Sowing)
            .ToListAsync();
    }
}