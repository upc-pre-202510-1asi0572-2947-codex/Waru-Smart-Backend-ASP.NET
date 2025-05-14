namespace WaruSmart.API.Crops.Domain.Model.Commands;

public record CreateDeviceCommand(
    string SensorType,
    string location,
    string status,
    int sowingId
    );