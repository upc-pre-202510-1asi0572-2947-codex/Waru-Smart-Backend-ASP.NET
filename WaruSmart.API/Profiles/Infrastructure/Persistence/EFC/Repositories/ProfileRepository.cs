using Microsoft.EntityFrameworkCore;
using WaruSmart.API.Profiles.Domain.Model.Aggregates;
using WaruSmart.API.Profiles.Domain.Model.ValueObjects;
using WaruSmart.API.Profiles.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }

    public Task<Profile?> GetProfileByIdAsync(int profileId)
    {
        return Context.Set<Profile>().FirstOrDefaultAsync(p => p.Id == profileId);
    }
    public async Task UpdateProfile(Profile profile)
    {
        Context.Set<Profile>().Update(profile);
        await Context.SaveChangesAsync();
    }
}