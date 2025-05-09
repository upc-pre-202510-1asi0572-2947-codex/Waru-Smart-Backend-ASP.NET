using WaruSmart.API.Profiles.Domain.Model.Commands;
using WaruSmart.API.Profiles.Domain.Model.Entities;
using WaruSmart.API.Profiles.Domain.Repositories;
using WaruSmart.API.Profiles.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Profiles.Application.Internal.CommandServices;

public class SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork) : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        try
        {
            await subscriptionRepository.AddAsync(subscription);
            await unitOfWork.CompleteAsync();
            return subscription;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}