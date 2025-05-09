using WaruSmart.API.Forum.Domain.Model.Entities;
using WaruSmart.API.Forum.Domain.Model.Queries;
using WaruSmart.API.Forum.Domain.Repositories;
using WaruSmart.API.Forum.Domain.Services;


namespace WaruSmart.API.Forum.Application.QueryService;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }

    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.CategoryId);
    }
}