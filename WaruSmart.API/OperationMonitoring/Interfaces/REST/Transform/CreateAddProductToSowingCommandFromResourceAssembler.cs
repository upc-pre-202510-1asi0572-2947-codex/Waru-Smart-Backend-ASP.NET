using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

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