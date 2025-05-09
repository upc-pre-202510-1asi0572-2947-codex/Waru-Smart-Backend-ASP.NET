using WaruSmart.API.Profiles.Domain.Model.Aggregates;
using WaruSmart.API.Profiles.Domain.Model.Commands;
using WaruSmart.API.Profiles.Domain.Repositories;
using WaruSmart.API.Profiles.Domain.Services;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    private IProfileCommandService profileCommandServiceImplementation;

    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }

    public async Task<Profile?> Handle(UpdateProfileCommand command)
    {
        var profile = await profileRepository.GetProfileByIdAsync(command.ProfileId);
        if (profile == null) return null;

        profile.UpdateProfile(
            command.FullName,
            command.EmailAddress,
            command.CountryId,
            command.CityId,
            command.SubscriptionId
        );

        await profileRepository.UpdateProfile(profile);
        return profile;
    }
}