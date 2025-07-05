using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public static class CreateDeviceCommandFromResourceAssembler
{
    public static CreateDeviceCommand ToCommandFromResource(CreateDeviceResource resource)
    {
        return new CreateDeviceCommand(
            resource.DeviceId,
            resource.DeviceType,
            resource.Location,
            resource.Status,
            resource.SowingId
        );
    }
}