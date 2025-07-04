using WaruSmart.API.Crops.Domain.Model.Commands;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public class UpdateCropSourceCommandFromResourceAssembler
{
    public static UpdateCropCommand ToCommandFromResource(UpdateCropResource resource)
    {
        return new UpdateCropCommand(resource.Name, resource.Description);
    }
}