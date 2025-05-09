using WaruSmart.API.Profiles.Domain.Model.ValueObjects;

namespace WaruSmart.API.Profiles.Domain.Model.Querys;

public record GetProfileByEmailQuery(EmailAddress Email);