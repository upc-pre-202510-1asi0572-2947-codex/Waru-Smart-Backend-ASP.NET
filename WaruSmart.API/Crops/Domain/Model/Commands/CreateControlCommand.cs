using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Domain.Model.Commands;

public record CreateControlCommand(int SowingId, ESowingCondition SowingCondition, ESowingStemCondition StemCondition,  ESowingSoilMoisture SoilMoisture);