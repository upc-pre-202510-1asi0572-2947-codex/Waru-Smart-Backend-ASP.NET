namespace WaruSmart.API.Crops.Interfaces.REST.Resources;

public record CreateDeviceResource( 
    string DeviceId,
    string SensorType,
    string Location,
    string Status,
    int SowingId
);