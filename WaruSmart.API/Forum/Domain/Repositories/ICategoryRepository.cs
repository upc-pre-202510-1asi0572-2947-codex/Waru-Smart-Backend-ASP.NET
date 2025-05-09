using WaruSmart.API.Forum.Domain.Model.Entities;
using WaruSmart.API.Shared.Domain.Repositories;

namespace WaruSmart.API.Forum.Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    bool ExistsByCategoryName(string name);
}