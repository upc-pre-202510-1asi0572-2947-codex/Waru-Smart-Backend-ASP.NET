﻿using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Domain.Model.ValueObjects;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public static class CreateControlSourceCommandFromResourceAssembler
{
    public static CreateControlCommand ToCommandFromResource(int sowingId, CreateControlResource resource)
    {
        if (!Enum.TryParse(resource.SowingCondition, out ESowingCondition condition))
        {
            throw new ArgumentException($"Invalid value for ESowingCondition: {resource.SowingCondition}");
        }

        if (!Enum.TryParse(resource.SoilMoisture, out ESowingSoilMoisture soilMoisture))
        {
            throw new ArgumentException($"Invalid value for ESowingSoilMoisture: {resource.SoilMoisture}");
        }

        if (!Enum.TryParse(resource.StemCondition, out ESowingStemCondition stemCondition))
        {
            throw new ArgumentException($"Invalid value for ESowingStemCondition: {resource.StemCondition}");
        }

        return new CreateControlCommand(sowingId, condition,stemCondition, soilMoisture);
    }
}