using WaruSmart.API.OperationMonitoring.Domain.Model.Entities;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class ControlResourceFromEntityAssembler
{
    public static ControlResource ToResourceFromEntity(Control entity)
    {
        return new ControlResource(entity.Id, entity.SowingId,  entity.Date, entity.SowingCondition.ToString(),entity.StemCondition.ToString(), entity.SoilMoisture.ToString());
    }
}