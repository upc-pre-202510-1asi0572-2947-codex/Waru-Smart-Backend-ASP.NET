using WaruSmart.API.OperationMonitoring.Domain.Model.Commands;
using WaruSmart.API.OperationMonitoring.Interfaces.REST.Resources;

namespace WaruSmart.API.OperationMonitoring.Interfaces.REST.Transform;

public static class CreateCropSourceCommandFromResourceAssembler
{
    public static CreateCropCommand ToCommandFromResource(CreateCropResource resource)
    {
        return new CreateCropCommand(resource.Name, resource.ImageUrl, resource.Description/*resource.Diseases,resource.Pests, resource.Cares*/);
    }
}