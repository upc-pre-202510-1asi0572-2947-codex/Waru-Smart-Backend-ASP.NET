namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

public record CreateDeviceResource( 
    string DeviceId,
    string SensorType,
    string Location,
    string Status,
    int SowingId
);