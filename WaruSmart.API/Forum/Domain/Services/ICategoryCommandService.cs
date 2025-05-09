using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Domain.Model.Entities;

namespace WaruSmart.API.Forum.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category?> Handle(CreateCategoryCommand command);
    Task<Category> Handle(UpdateCategoryCommand command);
    Task Handle(DeleteCategoryCommand command);
}