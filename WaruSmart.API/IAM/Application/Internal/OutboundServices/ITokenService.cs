using WaruSmart.API.IAM.Domain.Model.Aggregates;

namespace WaruSmart.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}