using WaruSmart.API.Profiles.Domain.Model.Aggregates;
using WaruSmart.API.Profiles.Domain.Model.Commands;

namespace WaruSmart.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);

    Task<Profile?> Handle(UpdateProfileCommand command);
}