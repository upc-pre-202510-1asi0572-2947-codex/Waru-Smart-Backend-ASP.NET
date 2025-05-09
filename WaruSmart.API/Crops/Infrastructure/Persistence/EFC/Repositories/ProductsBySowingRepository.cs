using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class ProductsBySowingRepository(AppDbContext context) :  BaseRepository<ProductsBySowing>(context), IProductsBySowingRepository
{
    
}