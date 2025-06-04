using WaruSmart.API.OperationMonitoring.Domain.Model.ValueObjects;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

public record UpdateControlResource(ESowingCondition SowingCondition, ESowingSoilMoisture SoilMoisture, ESowingStemCondition StemCondition);