namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

public record CreateControlResource(int SowingId, string SowingCondition,string StemCondition, string SoilMoisture);