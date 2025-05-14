/*using Microsoft.EntityFrameworkCore;
using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class DiseaseRepository  : BaseRepository<Disease>, IDiseaseRepository
{
    public DiseaseRepository(AppDbContext context) : base(context)
    {
        
    }
    
    public async Task<IEnumerable<Disease>> FindAllAsync()
    {
        return await Context.Set<Disease>().ToListAsync();
    }
    
    public async Task<IEnumerable<Disease>> GetDiseasesByCropId(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Diseases)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Diseases;
    }
}*/