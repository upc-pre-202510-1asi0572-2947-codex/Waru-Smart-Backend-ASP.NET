namespace WaruSmart.API.Crops.Interfaces.REST.Resources;

public record CreateDeviceResource( 
    string DeviceId,
    string DeviceType,
    string Location,
    string Status
);