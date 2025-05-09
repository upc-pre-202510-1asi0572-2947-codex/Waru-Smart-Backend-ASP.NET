using WaruSmart.API.Profiles.Domain.Model.Commands;
using WaruSmart.API.Profiles.Domain.Model.Entities;

namespace WaruSmart.API.Profiles.Domain.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
}