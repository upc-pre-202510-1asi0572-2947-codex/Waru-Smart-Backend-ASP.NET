using WaruSmart.API.Profiles.Domain.Model.Commands;
using WaruSmart.API.Profiles.Interfaces.REST.Resources;

namespace WaruSmart.API.Profiles.Interfaces.REST.Transform;

public static class CreateSubscriptionCommandFromResourceAssembler
{
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionResource resource)
    {
        return new CreateSubscriptionCommand(resource.Description, resource.Price, resource.Range);
    }
}