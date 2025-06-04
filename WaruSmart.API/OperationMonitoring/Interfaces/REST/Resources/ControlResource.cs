namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

public record ControlResource(int Id,int SowingId, DateTime Date ,string SowingCondition, string StemCondition, string SoilMoisture);
