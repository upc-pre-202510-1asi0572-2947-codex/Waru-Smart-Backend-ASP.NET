using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class PestRepository : BaseRepository<Pest>, IPestRepository
{
    public PestRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Pest>> FindAllAsync()
    {
        return await Context.Set<Pest>().ToListAsync();
    }
    public async Task<IEnumerable<Pest>> GetPestByCropIdQuery(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Pests)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Pests;
    }
}