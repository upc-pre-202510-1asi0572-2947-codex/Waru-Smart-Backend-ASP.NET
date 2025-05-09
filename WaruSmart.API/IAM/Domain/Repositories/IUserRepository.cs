using WaruSmart.API.IAM.Domain.Model.Aggregates;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}