namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record AddDeviceToSowingCommand(
    int SowingId,
    string Name,
    string Geolocation
);
