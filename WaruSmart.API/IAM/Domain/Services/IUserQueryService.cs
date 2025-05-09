using WaruSmart.API.IAM.Domain.Model.Aggregates;
using WaruSmart.API.IAM.Domain.Model.Queries;

namespace WaruSmart.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}