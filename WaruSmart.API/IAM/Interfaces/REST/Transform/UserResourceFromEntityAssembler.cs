using WaruSmart.API.IAM.Domain.Model.Aggregates;
using WaruSmart.API.IAM.Interfaces.REST.Resources;

namespace WaruSmart.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}