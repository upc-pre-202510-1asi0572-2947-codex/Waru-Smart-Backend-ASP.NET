using WaruSmart.API.Crops.Domain.Model.ValueObjects;

namespace WaruSmart.API.Crops.Interfaces.REST.Resources;

public record UpdateControlResource(ESowingCondition SowingCondition, ESowingSoilMoisture SoilMoisture, ESowingStemCondition StemCondition);