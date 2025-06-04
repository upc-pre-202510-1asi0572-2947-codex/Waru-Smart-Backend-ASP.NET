using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;

namespace WaruSmart.API.OperationMonitoring.Domain.Services;

public interface IProductCommandService
{
    Task<Product> Handle(CreateProductCommand command);
}