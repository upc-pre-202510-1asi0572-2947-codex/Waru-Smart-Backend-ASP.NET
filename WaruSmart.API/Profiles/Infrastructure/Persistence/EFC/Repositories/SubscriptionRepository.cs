using WaruSmart.API.Profiles.Domain.Model.Entities;
using WaruSmart.API.Profiles.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    
}