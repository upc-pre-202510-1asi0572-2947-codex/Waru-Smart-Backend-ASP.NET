using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.Queries;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.OperationMonitoring.Domain.Services;

namespace WaruSmart.API.OperationMonitoring.Application.QueryServices;

public class ProductQueryService(IProductRepository productRepository ): IProductQueryService
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();

    }

    public async Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery query)
    {
        return await productRepository.FindByTypeAsync(query.Type);
    }

    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
}