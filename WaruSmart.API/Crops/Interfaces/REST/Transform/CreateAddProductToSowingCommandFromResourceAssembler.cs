using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public class CreateAddProductToSowingCommandFromResourceAssembler
{
    public static AddProductToSowingCommand toCommandFromResource(AddProductToSowingResource resource)
    {
        return new AddProductToSowingCommand(
            resource.SowingId,
            resource.ProductId,
            resource.Quantity,
            DateTime.Now
        );
    }
}