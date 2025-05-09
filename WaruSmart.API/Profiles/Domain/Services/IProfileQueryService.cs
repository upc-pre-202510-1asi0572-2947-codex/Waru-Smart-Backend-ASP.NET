using WaruSmart.API.Profiles.Domain.Model.Aggregates;
using WaruSmart.API.Profiles.Domain.Model.Querys;

namespace WaruSmart.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}