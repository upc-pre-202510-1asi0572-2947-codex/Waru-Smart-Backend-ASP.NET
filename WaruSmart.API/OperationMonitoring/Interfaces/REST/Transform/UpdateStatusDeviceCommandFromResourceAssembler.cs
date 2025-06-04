using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class UpdateStatusDeviceCommandFromResourceAssembler
{
    public static UpdateStatusDeviceCommand ToCommandFromResource(UpdateStatusDeviceResource resource)
    {
        return new UpdateStatusDeviceCommand(
            resource.Status
        );
    }
}