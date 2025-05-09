using WaruSmart.API.Forum.Domain.Model.Entities;
using WaruSmart.API.Forum.Domain.Model.Queries;

namespace WaruSmart.API.Forum.Domain.Services;

public interface ICategoryQueryService
{
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    Task<Category?> Handle(GetCategoryByIdQuery query);
}