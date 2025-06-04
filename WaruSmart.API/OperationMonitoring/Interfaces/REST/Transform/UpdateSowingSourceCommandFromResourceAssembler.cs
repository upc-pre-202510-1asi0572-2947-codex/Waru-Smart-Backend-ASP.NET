using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public class UpdateSowingSourceCommandFromResourceAssembler
{
    public static UpdateSowingCommand ToCommandFromResource(UpdateSowingResource resource)
    {
        return new UpdateSowingCommand(resource.AreaLand,resource.CropId);
    }
}