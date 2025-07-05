namespace WaruSmart.API.Crops.Domain.Model.Events;

public record UpdateStatusDeviceEvent(
    int DeviceId,
    string Status);