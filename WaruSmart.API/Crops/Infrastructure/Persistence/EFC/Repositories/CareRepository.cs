/*using Microsoft.EntityFrameworkCore;
using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class CareRepository: BaseRepository<Care>, ICareRepository
{
    public CareRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task<IEnumerable<Care>> GetCaresByCropIdQuery(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Cares)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Cares;
    }
}*/