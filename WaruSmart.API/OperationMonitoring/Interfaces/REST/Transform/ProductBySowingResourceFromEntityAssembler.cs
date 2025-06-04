using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public class ProductBySowingResourceFromEntityAssembler
{
    public static ProductBySowingResource ToResourceFromEntity(ProductsBySowing entity)
    {
        return new ProductBySowingResource( entity.UseDate, entity.Quantity);
    }
}