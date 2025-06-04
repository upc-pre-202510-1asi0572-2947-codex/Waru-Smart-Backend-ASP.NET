using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Repositories;
using WaruSmart.API.OperationMonitoring.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.OperationMonitoring.Application.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product> Handle(CreateProductCommand command)
    {
        var product = new Product(command);
        try
        {
            await productRepository.AddAsync(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Product", e);
        }
    }
}