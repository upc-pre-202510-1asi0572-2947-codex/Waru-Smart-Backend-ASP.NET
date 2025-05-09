using WaruSmart.API.Profiles.Domain.Model.ValueObjects;

namespace WaruSmart.API.Profiles.Domain.Model.Commands;

public record CreateSubscriptionCommand(string Description, decimal Price, int Range);