using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public class UpdateCropSourceCommandFromResourceAssembler
{
    public static UpdateCropCommand ToCommandFromResource(UpdateCropResource resource)
    {
        return new UpdateCropCommand(resource.Name, resource.Description);
    }
}