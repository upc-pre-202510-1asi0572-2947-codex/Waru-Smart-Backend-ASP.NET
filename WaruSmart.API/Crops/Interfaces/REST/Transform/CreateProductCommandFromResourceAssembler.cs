using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.ValueObjects;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

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