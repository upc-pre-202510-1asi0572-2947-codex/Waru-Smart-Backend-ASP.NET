﻿namespace WaruSmart.API.Crops.Interfaces.REST.Resources;

public record CreateControlResource(int SowingId, string SowingCondition,string StemCondition, string SoilMoisture);