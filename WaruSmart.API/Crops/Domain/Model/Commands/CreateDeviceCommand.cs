namespace WaruSmart.API.Crops.Domain.Model.Commands;

public record CreateDeviceCommand(
    string DeviceId,
    string DeviceType,
    string location,
    string status,
    int sowingId
    );