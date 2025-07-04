using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public class UpdateSowingSourceCommandFromResourceAssembler
{
    public static UpdateSowingCommand ToCommandFromResource(UpdateSowingResource resource)
    {
        return new UpdateSowingCommand(resource.AreaLand,resource.CropId);
    }
}