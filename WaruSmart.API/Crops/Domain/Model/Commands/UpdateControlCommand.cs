using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Domain.Model.Commands;

public record UpdateControlCommand(int Id, int SowingId, ESowingCondition SowingCondition, ESowingStemCondition StemCondition, ESowingSoilMoisture SoilMoisture);