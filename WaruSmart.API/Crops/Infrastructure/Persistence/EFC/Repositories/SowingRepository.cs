using Microsoft.EntityFrameworkCore;
using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class SowingRepository : BaseRepository<Sowing>, ISowingRepository
{
    public SowingRepository(AppDbContext context):base(context)
    {
    } 
    public async Task<IEnumerable<Sowing>> FindByStatusAsync(bool status)
    {
        return await Context.Set<Sowing>().Where(f => f.Status == status)
            .ToListAsync();
    }

    public async Task UpdateAsync(Sowing sowing)
    {
    Context.Set<Sowing>().Update(sowing);
    await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> FindProductsBySowing(int sowingId)
    {
        var productsBySowing = await Context.Set<ProductsBySowing>()
            .Include(pbs => pbs.Product)
            .Where(pbs => pbs.SowingId == sowingId)
            .ToListAsync();

        return productsBySowing.Select(pbs => pbs.Product);

    }
    public async Task<IEnumerable<Sowing>> FindAllAsync()
    {
        return await Context.Set<Sowing>().ToListAsync();
    }
}