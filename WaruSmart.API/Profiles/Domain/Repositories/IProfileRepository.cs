using WaruSmart.API.Profiles.Domain.Model.Aggregates;
using WaruSmart.API.Profiles.Domain.Model.ValueObjects;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
    Task<Profile?> GetProfileByIdAsync(int profileId);
    Task UpdateProfile(Profile profile);
}