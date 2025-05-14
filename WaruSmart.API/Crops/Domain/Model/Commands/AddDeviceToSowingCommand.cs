namespace WaruSmart.API.Crops.Domain.Model.Commands;

public record AddDeviceToSowingCommand(
    int SowingId,
    string Name,
    string Geolocation
);
