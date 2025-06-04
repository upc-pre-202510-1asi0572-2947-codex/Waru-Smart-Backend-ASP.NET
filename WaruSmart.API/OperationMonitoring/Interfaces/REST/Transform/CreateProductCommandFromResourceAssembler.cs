using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        if( Enum.TryParse<EProductType>(resource.Type, out var type))
        {
            return new CreateProductCommand(resource.Name, type);
        }
        else
        {
            throw new ArgumentException("Invalid product type");
        }
    }
}