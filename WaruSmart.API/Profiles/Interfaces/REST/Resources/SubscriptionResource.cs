using WaruSmart.API.Profiles.Domain.Model.ValueObjects;

namespace WaruSmart.API.Profiles.Interfaces.REST.Resources;

public record SubscriptionResource(int Id, string Description, decimal Price, int Range);