using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public static class SowingResourceFromEntityAssembler
{
    public static SowingResource ToResourceFromEntity(Sowing entity)
    {
        return new SowingResource(entity.Id,
            entity.StartDate,
            entity.EndDate,
            entity.AreaLand,
            entity.Status,
            entity.PhenologicalPhase,
            entity.CropId,
            entity.PhenologicalPhase.ToString(),
            entity.UserId
            );
    
}
}

