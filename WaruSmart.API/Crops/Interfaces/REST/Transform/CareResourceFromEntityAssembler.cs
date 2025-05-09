using WaruSmart.API.Crops.Domain.Model.Entities;
using WaruSmart.API.Crops.Interfaces.REST.Resources;

namespace WaruSmart.API.Crops.Interfaces.REST.Transform;

public class CareResourceFromEntityAssembler
{
    public static CareResource ToResourceFromEntity(Care entity)
    {
        return new CareResource(entity.Id, entity.Suggestion, entity.Date);
    }
}