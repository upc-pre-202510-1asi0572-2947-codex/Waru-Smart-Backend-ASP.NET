using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Domain.Model.ValueObjects;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Crops.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    /**
     * Method of the interface that allows to search for a product by its type
     */
    Task<IEnumerable<Product>> FindByTypeAsync(EProductType type);
    
}