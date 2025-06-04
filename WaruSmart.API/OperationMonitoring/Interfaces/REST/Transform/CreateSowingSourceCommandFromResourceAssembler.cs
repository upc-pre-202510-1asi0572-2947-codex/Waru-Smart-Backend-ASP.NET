using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class CreateSowingSourceCommandFromResourceAssembler
{
    public static CreateSowingCommand ToCommandFromResource(CreateSowingResource resource)
    {
        return new CreateSowingCommand(resource.AreaLand,resource.CropId, resource.UserId);
    }
}