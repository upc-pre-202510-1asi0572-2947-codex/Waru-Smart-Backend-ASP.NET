using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface IProductQueryService
{
    /**
     * Return all products
     */
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    
    /**
     * Return products by type
     */
    Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery query);
    
    /**
     * Return product by id
     */
    Task<Product?> Handle(GetProductByIdQuery query);
}