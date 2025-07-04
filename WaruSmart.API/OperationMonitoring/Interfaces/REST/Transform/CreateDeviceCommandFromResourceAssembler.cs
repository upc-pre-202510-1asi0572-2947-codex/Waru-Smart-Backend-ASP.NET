using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class CreateDeviceCommandFromResourceAssembler
{
    public static CreateDeviceCommand ToCommandFromResource(CreateDeviceResource resource)
    {
        return new CreateDeviceCommand(
            resource.DeviceId,
            resource.SensorType,
            resource.Location,
            resource.Status,
            resource.SowingId
        );
    }
}