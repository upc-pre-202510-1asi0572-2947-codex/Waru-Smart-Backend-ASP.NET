using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class DeviceResourceFromEntityAssembler
{
    public static DeviceResource ToResourceFromEntity(Device device)
    {
        return new DeviceResource(
            device.Id,
            device.Name,
            device.SensorType.ToString(),
            device.DeviceId,
            device.Status,
            device.LastSyncDate,
            device.Location,
            device.SowingId,
            device.Humidity,
            device.Temprature,
            device.SoilMoisture,
            device.LastSyncDate
        );

    }
}