using Microsoft.EntityFrameworkCore;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.OperationMonitoring.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> FindByTypeAsync(EProductType type)
    {
        return await Context.Set<Product>().Where(f => f.Type == type)
            .ToListAsync();
    }
}