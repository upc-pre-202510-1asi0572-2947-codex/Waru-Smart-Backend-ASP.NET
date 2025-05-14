namespace WaruSmart.API.Crops.Interfaces.REST.Resources;

public record DeviceResource(
    int Id,
    string Name,
    string SensorType,
    string DeviceId,
    string Status,
    DateTime? LastSyncDate,
    string Location,
    int SowingId
);