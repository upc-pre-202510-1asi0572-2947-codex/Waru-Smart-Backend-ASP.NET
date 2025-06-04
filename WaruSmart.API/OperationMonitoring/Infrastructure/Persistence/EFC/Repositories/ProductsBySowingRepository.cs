using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.OperationMonitoring.Infrastructure.Persistence.EFC.Repositories;

public class ProductsBySowingRepository(AppDbContext context) :  BaseRepository<ProductsBySowing>(context), IProductsBySowingRepository
{
    
}