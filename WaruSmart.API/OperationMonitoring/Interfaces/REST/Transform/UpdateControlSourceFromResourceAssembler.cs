using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public class UpdateControlSourceFromResourceAssembler
{
    public static UpdateControlCommand ToCommandFromResource(UpdateControlResource resource,int sowingId, int sowingControlId ) {
        return new UpdateControlCommand(
            sowingId,
            sowingControlId,
            resource.SowingCondition,
            resource.StemCondition,
            resource.SoilMoisture
        );
    }
}