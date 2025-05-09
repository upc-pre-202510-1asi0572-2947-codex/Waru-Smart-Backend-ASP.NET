using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Interfaces.REST.Resources;

namespace WaruSmart.API.Forum.Interfaces.REST.Transform;

public static class UpdateCategoryCommandFromResourceAssembler
{
    public static UpdateCategoryCommand ToCommandFromResource(int categoryId, UpdateCategoryResource resource)
    {
        return new UpdateCategoryCommand(categoryId, resource.Name);
    }
}