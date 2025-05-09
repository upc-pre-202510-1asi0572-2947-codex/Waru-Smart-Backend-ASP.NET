using WaruSmart.API.Profiles.Domain.Model.Entities;
using WaruSmart.API.Profiles.Interfaces.REST.Resources;

namespace WaruSmart.API.Profiles.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription subscription)
    {
        return new SubscriptionResource(subscription.Id, subscription.Description, subscription.Price, subscription.Range);
    }
}