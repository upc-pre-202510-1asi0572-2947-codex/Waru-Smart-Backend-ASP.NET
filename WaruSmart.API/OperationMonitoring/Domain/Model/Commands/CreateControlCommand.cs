using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;

namespace WaruSmart.API.OperationMonitoring.Domain.Model.Commands;

public record CreateControlCommand(int SowingId, ESowingCondition SowingCondition, ESowingStemCondition StemCondition,  ESowingSoilMoisture SoilMoisture);