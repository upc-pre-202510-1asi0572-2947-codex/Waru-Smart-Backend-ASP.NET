using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

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