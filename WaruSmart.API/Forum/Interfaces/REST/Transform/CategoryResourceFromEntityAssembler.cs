using WaruSmart.API.Forum.Domain.Model.Entities;
using WaruSmart.API.Forum.Interfaces.REST.Resources;

namespace WaruSmart.API.Forum.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}