using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;

namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record UpdateControlCommand(int Id, int SowingId, ESowingCondition SowingCondition, ESowingStemCondition StemCondition, ESowingSoilMoisture SoilMoisture);