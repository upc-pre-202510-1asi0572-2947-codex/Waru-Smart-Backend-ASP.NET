﻿using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public static class CropResourceFromEntityAssembler
{
    public static CropResource ToResourceFromEntity(Crop entity)
    {
        /*var diseaseIds = entity.Diseases?.Select(d => d.Id).ToList() ?? new List<int>();
        var pestIds = entity.Pests?.Select(p => p.Id).ToList() ?? new List<int>();
        var careIds = entity.Cares?.Select(c => c.Id).ToList() ?? new List<int>();*/

        return new CropResource(entity.Id, entity.Name, entity.Description, entity.ImageUrl /*diseaseIds, pestIds,
            careIds*/);
    }
}