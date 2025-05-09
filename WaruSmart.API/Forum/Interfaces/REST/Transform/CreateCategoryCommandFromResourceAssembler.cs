using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Interfaces.REST.Resources;

namespace WaruSmart.API.Forum.Interfaces.REST.Transform;

public static class CreateCategoryCommandFromResourceAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name);
    }
}