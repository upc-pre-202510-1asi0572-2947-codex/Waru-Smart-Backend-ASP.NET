using WaruSmart.API.Forum.Domain.Model.Entities;
using WaruSmart.API.Forum.Domain.Repositories;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WaruSmart.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace WaruSmart.API.Forum.Infrastructure.Persistence.EFC.Repositories;

public class CategoryRepository(AppDbContext context) : BaseRepository<Category>(context), ICategoryRepository
{
    public bool ExistsByCategoryName(string name)
    {
        return Context.Set<Category>().Any(c=>c.Name == name);
    }
}