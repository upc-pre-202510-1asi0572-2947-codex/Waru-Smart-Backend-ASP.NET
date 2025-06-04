namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

public record CreateDeviceResource( 
    string SensorType,
    string Location,
    string Status,
    int SowingId
);