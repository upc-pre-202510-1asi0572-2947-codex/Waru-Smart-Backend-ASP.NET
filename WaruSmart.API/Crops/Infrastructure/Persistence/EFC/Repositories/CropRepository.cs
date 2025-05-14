using Microsoft.EntityFrameworkCore;
using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class CropRepository : BaseRepository<Crop>, ICropRepository
{
    public CropRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task UpdateAsync(Crop crop)
    {
        Context.Set<Crop>().Update(crop);
        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Crop>> FindAllAsync()
    {
        return await Context.Set<Crop>()
            /*.Include(c => c.Diseases)
            .Include(c => c.Pests)
            .Include(c => c.Cares)*/
            .ToListAsync();
    }
    public new async Task<Crop?> FindByIdAsync(int id)
    {
        return await Context.Set<Crop>()
            /*.Include(c => c.Diseases)
            .Include(c => c.Pests)
            .Include(c => c.Cares)*/
            .SingleOrDefaultAsync(c => c.Id == id);
    }
}