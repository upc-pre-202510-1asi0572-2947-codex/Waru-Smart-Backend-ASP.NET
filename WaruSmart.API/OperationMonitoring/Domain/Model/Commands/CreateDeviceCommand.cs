namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record CreateDeviceCommand(
    string DeviceId,
    string SensorType,
    string location,
    string status,
    int sowingId
    );