﻿using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WaruSmart.API.Forum.Domain.Model.Commands;
using WaruSmart.API.Forum.Domain.Model.Queries;
using WaruSmart.API.Forum.Domain.Services;
using WaruSmart.API.Forum.Interfaces.REST.Resources;
using WaruSmart.API.Forum.Interfaces.REST.Transform;

namespace WaruSmart.API.Forum.Interfaces.REST;

[ApiController]
[Route("api/v1/forum/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CategoriesController(ICategoryCommandService categoryCommandService, ICategoryQueryService categoryQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryResource resource)
    {
        var createCategoryCommand = CreateCategoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var category = await categoryCommandService.Handle(createCategoryCommand);
        if (category is null) return BadRequest();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = categoryResource.CategoryId }, categoryResource);
    }
    
    [HttpPut("{categoryId}")]
    public async Task<ActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] UpdateCategoryResource resource)
    {
        var updateCategoryCommand = UpdateCategoryCommandFromResourceAssembler.ToCommandFromResource(categoryId, resource);
        var category = await categoryCommandService.Handle(updateCategoryCommand);
        if (category is null) return NotFound();
        var categoryResource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(categoryResource);
    }
    
    [HttpDelete("{categoryId}")]
    public async Task<ActionResult> DeleteCategory([FromRoute] int categoryId)
    {
        var deleteCategoryCommand = new DeleteCategoryCommand(categoryId);
        await categoryCommandService.Handle(deleteCategoryCommand);
        return Ok("Category with given id successfully deleted.");
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAllCategories()
    {
        var getAllCategoriesQuery = new GetAllCategoriesQuery();
        var categories = await categoryQueryService.Handle(getAllCategoriesQuery);
        var resources = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{categoryId}")]
    public async Task<ActionResult> GetCategoryById([FromRoute] int categoryId)
    {
        var getCategoryById = new GetCategoryByIdQuery(categoryId);
        var category = await categoryQueryService.Handle(getCategoryById);
        if (category is null) return NotFound();
        var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }
}