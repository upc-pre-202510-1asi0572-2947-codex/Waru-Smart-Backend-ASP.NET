using WaruSmart.API.OperationMonitoring.Domain.Model.Aggregates;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

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

