using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class GeneralInformationDeviceResourceFromListEntitiesAssembler
{
    public static GeneralInformationDeviceResource ToResourceFromEntity(IEnumerable<Device> devices)
    {
        return new GeneralInformationDeviceResource(
            SowingId: devices.FirstOrDefault()?.SowingId ?? 0,
            QuantityDevices: devices.Count(),
            QuantityActiveDevices: devices.Count(d => d.Status == "Active"),
            QuantityInactiveDevices: devices.Count(d => d.Status == "Inactive"),
            QuantityDisconnectedDevices: devices.Count(d => d.Status == "Disconnected"),
            QuantityHumidityDevices: devices.Count(d => d.SensorType == ESensorType.Humidity),
            QuantityTemperatureDevices: devices.Count(d => d.SensorType == ESensorType.Temperature),
            QuantitySoilMoistureDevices: devices.Count(d => d.SensorType == ESensorType.SoilMoisture)
        );
    }
}