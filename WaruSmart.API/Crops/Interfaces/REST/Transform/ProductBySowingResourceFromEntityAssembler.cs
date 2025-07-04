using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public class ProductBySowingResourceFromEntityAssembler
{
    public static ProductBySowingResource ToResourceFromEntity(ProductsBySowing entity)
    {
        return new ProductBySowingResource( entity.UseDate, entity.Quantity);
    }
}